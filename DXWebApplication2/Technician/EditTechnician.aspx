﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="EditTechnician.aspx.cs" Inherits="DXWebApplication2.Technician.EditTechnician" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 179px">ID ตำแหน่ง</td>
            <td>
                <asp:TextBox ID="idTxt" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">รหัสตำแหน่ง</td>
            <td>
                <asp:TextBox ID="codeTxt" runat="server" Enabled="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px;">ชื่อตำแหน่ง</td>
            <td style="height: 29px">
                <asp:TextBox ID="subtitleTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px">ค่าแรงต่อชั่วโมง</td>
            <td style="height: 29px">
                <asp:TextBox ID="hourRateTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px">คำอธิบาย</td>
            <td style="height: 29px">
                <asp:TextBox ID="remarkTxt" runat="server"></asp:TextBox>
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