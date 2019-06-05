<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="EditCompositionPart.aspx.cs" Inherits="DXWebApplication2.CompositionPart.EditCompositionPart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 179px">ID ส่วนประกอบ</td>
            <td>
                <asp:TextBox ID="idTxt" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px;">รหัสส่วนประกอบ</td>
            <td style="height: 29px">
                <asp:TextBox ID="codeTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px;">ชื่อส่วนประกอบ</td>
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
            <td style="width: 179px; height: 29px">รหัสชิ้นส่วนหลัก</td>
            <td style="height: 29px">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="vepSubtitle" DataValueField="vepId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT [vepSubtitle], [vepId] FROM [tblVehiclePart] where vepActive=1"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">&nbsp;</td>
            <td>
                <asp:Button ID="editBtn" runat="server" Text="Update" OnClick="editBtn_Click" />
                <asp:Button ID="backBtn" runat="server" Text="Back to list" OnClick="backBtn_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
