<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="AddMaterial.aspx.cs" Inherits="DXWebApplication2.AddMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width:100%;">
        <tr>
            <td style="width: 179px">รหัสวัสดุ</td>
            <td>
                <asp:TextBox ID="codeTxt" runat="server"></asp:TextBox>
            </td>
        </tr>   
        <tr>
            <td style="width: 179px; height: 29px;">ชื่อวัสดุ</td>
            <td style="height: 29px">
                <asp:TextBox ID="subtitleTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 30px;">รูป</td>
            <td style="height: 30px">
                <asp:TextBox ID="imageTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">ไฟล์</td>
            <td>
                <asp:TextBox ID="fileTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px">คำอธิบาย</td>
            <td style="height: 29px">
                <asp:TextBox ID="remarkTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px">ราคา</td>
            <td style="height: 29px">
                <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">&nbsp;</td>
            <td>
                <asp:Button ID="addVehicle" runat="server" Text="Create" OnClick="addVehicle_Click" />
                <asp:Button ID="backBtn" runat="server" Text="Back to list" OnClick="backBtn_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
