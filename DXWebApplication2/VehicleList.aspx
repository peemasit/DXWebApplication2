<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="VehicleList.aspx.cs" Inherits="DXWebApplication2.VehicleList" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <asp:GridView ID="gvVehicle" BorderWidth="1" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="vehId" HeaderText="รหัสรุ่นรถ"  />
                    <asp:BoundField DataField="vehSubtitle" HeaderText="ชื่อรุ่นรถ"  />
                    <asp:BoundField DataField="vehRemark" HeaderText="คำอธิบาย"  />
                    <asp:TemplateField HeaderText="รูป" >
                        <ItemTemplate>
                            <asp:Image Height="250px" ImageUrl='<%# Eval("vehImage") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="vehFile" HeaderText="ไฟล์" />
                    <asp:BoundField DataField="vetSubtitle" HeaderText="ชื่อประเภทรถ" />
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

