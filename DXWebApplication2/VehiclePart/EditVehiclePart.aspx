<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="EditVehiclePart.aspx.cs" Inherits="DXWebApplication2.VehiclePart.EditVehiclePart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td><table style="width:100%; margin-right: 0px;">
        <tr>
            <td style="width: 179px">ID ชิ้นส่วนหลัก</td>
            <td>
                <asp:TextBox ID="idTxt" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">รหัสชิ้นส่วนหลัก</td>
            <td>
                <asp:TextBox ID="codeTxt" runat="server" Enabled="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 179px; height: 29px;">ชื่อชิ้นส่วนหลัก</td>
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
       <%-- <tr>
            <td style="width: 179px; height: 29px">รหัสรุ่นรถ</td>
            <td style="height: 29px">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="vehSubtitle" DataValueField="vehId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT [vehSubtitle], [vehId] FROM [tblVehicle] where vehActive=1"></asp:SqlDataSource>
            </td>
        </tr>--%>
        <tr>
            <td style="width: 179px">&nbsp;</td>
            <td>
                <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
                <asp:Button ID="backBtn" runat="server" Text="Back to list" OnClick="backBtn_Click"/>
            </td>
        </tr>
    </table></td>
             <td>
                 <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" >
                     <Columns>
                         <asp:BoundField DataField="deCopId" HeaderText="deVepId" ReadOnly="True"  />
                         <asp:BoundField DataField="copSubtitle" HeaderText="รุ่นรถ"  />
                         <asp:BoundField DataField="vepSubtitle" HeaderText="ชิ้นส่วนหลัก" />
                     </Columns>
                 </asp:GridView>
                 <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT [vehSubtitle], [deVepId], [vepSubtitle] FROM [vw_DeVehiclePart]"></asp:SqlDataSource>--%>
            </td>
        </tr>
        
    </table>
    
</asp:Content>
