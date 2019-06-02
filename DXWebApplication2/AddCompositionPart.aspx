<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="AddCompositionPart.aspx.cs" Inherits="DXWebApplication2.AddCompositionPart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width:100%;">
        <tr>
            <td style="width: 179px">รหัสส่วนประกอบ</td>
            <td>
                <asp:TextBox ID="idTxt" runat="server"></asp:TextBox>
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
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="vepId" DataValueField="vepId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT [vepId] FROM [tblVehiclePart]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">&nbsp;</td>
            <td>
                <asp:Button ID="addVehicle" runat="server" Text="Create" OnClick="addVehicle_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
