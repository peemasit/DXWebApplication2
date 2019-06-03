<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="AddVehicleType.aspx.cs" Inherits="DXWebApplication2.Test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="height: 29px">ชื่อประเภทรถ</td>
            <td style="height: 29px">
                <asp:TextBox ID="subtitleTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">รูปรถ</td>
            <td style="height: 29px">
                <asp:TextBox ID="imageTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">รายละเอียด</td>
            <td>
                <asp:TextBox ID="remarkTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">&nbsp;</td>
            <td>
                <asp:Button ID="insertBtn" runat="server" OnClick="insertBtn_Click" Text="Create" />
                <asp:Button ID="backBtn" runat="server" OnClick="backBtn_Click" Text="Back to list" />
            </td>
        </tr>
    </table>
</asp:Content>
