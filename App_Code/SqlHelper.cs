﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// SqlHelper 的摘要说明
/// </summary>
public static class SqlHelper
{
    public static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr1"].ConnectionString;
    private static SqlConnection conn = new SqlConnection();
    private static SqlCommand comm = new SqlCommand();


    public static bool OpenConnection()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private static void openConnection()
    {
        if (conn.State == ConnectionState.Closed)
        {
            try
            {
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connstr1"].ConnectionString;
                comm.Connection = conn;
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    private static void closeConnection()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();
        comm.Dispose();
    }

    public static int ExecuteNonQuery(string cmdText,
        params SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteNonQuery(conn, cmdText, parameters);

            }

        }
        catch (Exception e)
        {
            //MessageBox.Show(e.Message);
            return 0;
        }
    }

    public static object ExecuteScalar(string cmdText,
        params SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }
        catch (Exception e)
        {
            //MessageBox.Show(e.Message);
            return 0;
        }
    }

    public static DataTable ExecuteDataTable(string cmdText,
        params SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, parameters);
            }
        }
        catch (Exception e)
        {
            //MessageBox.Show(e.Message);
            return null;
        }
    }

    public static int ExecuteNonQuery(SqlConnection conn, string cmdText,
       params SqlParameter[] parameters)
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
    }

    public static object ExecuteScalar(SqlConnection conn, string cmdText,
        params SqlParameter[] parameters)
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }

    public static DataTable ExecuteDataTable(SqlConnection conn, string cmdText,
        params SqlParameter[] parameters)
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.AddRange(parameters);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }

    public static object ToDBValue(this object value)
    {
        return value == null ? DBNull.Value : value;
    }

    static public SqlDataReader ExecuteReader(string sql, params SqlParameter[] paramer)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connstr;
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddRange(paramer);
        SqlDataReader dr = cmd.ExecuteReader();

        return dr;

    }

    public static DataSet dataSet(string sqlStr)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlStr;
            da.SelectCommand = comm;
            da.Fill(ds);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
        return ds;
    }

    /// <summary>
    /// 执行一条sql语句
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    public static void ExecuteSql(string sqlStr)
    {
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlStr;
            comm.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
    }

    public static object FromDBValue(this object dbValue)
    {
        return dbValue == DBNull.Value ? null : dbValue;
    }
}