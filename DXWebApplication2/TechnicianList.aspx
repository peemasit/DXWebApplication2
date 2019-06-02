<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TechnicianList.aspx.cs" Inherits="DXWebApplication2.TechnicianList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <asp:GridView ID="gvVehicle" BorderWidth="1" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="tecId" HeaderText="รหัสตำแหน่ง"  />
                    <asp:BoundField DataField="tecSubtitle" HeaderText="ชื่อตำแหน่ง"  />
                    <asp:BoundField DataField="tecHourRate" HeaderText="ค่าแรงต่อชั่วโมง" />
                    <asp:BoundField DataField="tecRemark" HeaderText="คำอธิบาย"  />
                    
                    <asp:TemplateField HeaderText="แก้ไช" >
                        <ItemTemplate>
                            <asp:Button id="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ลบ" >
                        <ItemTemplate>
                            <asp:Button id="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
