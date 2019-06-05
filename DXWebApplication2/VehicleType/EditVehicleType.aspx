<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="EditVehicleType.aspx.cs" Inherits="DXWebApplication2.EditVehicleType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <table style="width:100%;">
        <tr>
            <td style="height: 29px">รหัสประเภทรถ</td>
            <td style="height: 29px">
                <asp:TextBox ID="idTxt" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">ชื่อประเภทรถ</td>
            <td style="height: 29px">
                <asp:TextBox ID="subtitleTxt" runat="server" Enabled="true"></asp:TextBox>
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
                <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"  />
                <asp:Button ID="backBtn" runat="server" Text="Back to list" OnClick="backBtn_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
