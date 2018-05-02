<%@ Page MasterPageFile="site1.master" Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Account_Manage" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <meta http-equiv="Content-Type" name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no text/html,charset=utf-8" />
    <!-- 新 Bootstrap4 核心 CSS 文件 -->
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <!-- popper.min.js 用于弹窗、提示、下拉菜单 -->
    <script src="https://cdn.bootcss.com/popper.js/1.12.5/umd/popper.min.js"></script>
    <!-- 最新的 Bootstrap4 核心 JavaScript 文件 -->
    <script src="https://cdn.bootcss.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>

    <script src="js/Ajax.js" type="text/javascript"></script>
    <script src="js/Tree.js" type="text/javascript"></script>
    <script src="js/Dialog.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <link href="images/dialog/Dialog.css" rel="stylesheet" type="text/css" />
    <link href="css/WebExplorer.css" rel="stylesheet" type="text/css" />
    <script src="js/fckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="ct1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="fileExplorer">
        <div class="row">
            <div class="col-3" id="tree"></div>
        <div class="col-9" id="rightPanel">
            <div id="path">
                当前位置：<span id="pathString"></span>
            </div>
            <hr />
            <!-- 这里是菜单开始 -->
            <div id="menu">
                <div class="menuItem" onclick="javascript:gotoParentDirectory();">
                    <img class="menuItemImg" src="images/up.gif" />
                    <div class="tipText">
                        向上
                    </div>
                </div>
                <div class="menuItem" onclick="javascrip:goRoot();">
                    <img class="menuItemImg" src="images/home.gif" />
                    <div class="tipText">
                        根目录
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:refersh()">
                    <img class="menuItemImg" src="images/refersh.gif" />
                    <div class="tipText">
                        刷新
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:newDirectory();">
                    <img class="menuItemImg" src="images/newfolder.gif" />
                    <div class="tipText">
                        新目录
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:newFile();">
                    <img class="menuItemImg" src="images/newfile.gif" />
                    <div class="tipText">
                        新文件
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:del();">
                    <img class="menuItemImg" src="images/delete.gif" />
                    <div class="tipText">
                        删除
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:cut();">
                    <img class="menuItemImg" src="images/cut.gif" />
                    <div class="tipText">
                        剪切
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:copy();">
                    <img class="menuItemImg" src="images/copy.gif" />
                    <div class="tipText">
                        复制
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:paste();">
                    <img class="menuItemImg" src="images/paste.gif" />
                    <div class="tipText">
                        粘贴
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:zipFile();">
                    <img class="menuItemImg" src="images/zipfile.gif" />
                    <div class="tipText">
                        压缩
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:unZipFile();">
                    <img class="menuItemImg" src="images/unzip.gif" />
                    <div class="tipText">
                        解压
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:downLoad();">
                    <img class="menuItemImg" src="images/download.gif" />
                    <div class="tipText">
                        下载
                    </div>
                </div>
                <div class="menuItem" onclick="javascript:uploadFile();">
                    <img class="menuItemImg" src="images/upload.gif" />
                    <div class="tipText">
                        上传
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <!-- 这里是菜单结束 -->
            <!-- 这里是文件列表开始 -->
            <div id="fileListHead">
                <div class="chkColumn">
                    <input type="checkbox" id="checkAll" onclick="javascript: selectAll();" title="全部选中" />
                </div>
                <div class="fileType">
                    类型
                </div>
                <div class="fileName">
                    名称
                </div>
                <div class="fileSize">
                    大小
                </div>
                <div class="lastUpdate">
                    最后更新
                </div>
                <div class="rename">
                    重命名
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="fileList"></div>
            <!-- 这里是文件列表结束 -->
        </div>
        </div>
    </div>
    <script src="js/WebExplorerMain.js" type="text/javascript"></script>
</asp:Content>
