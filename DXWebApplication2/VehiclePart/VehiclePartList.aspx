<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="VehiclePartList.aspx.cs" Inherits="DXWebApplication2.VehiclePartList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <asp:GridView ID="gvVehicle" runat="server"
                AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:BoundField DataField="vepId" HeaderText="ID ชิ้นส่วนหลัก"  />
                    <asp:BoundField DataField="vepCode" HeaderText="รหัสชิ้นส่วนหลัก"  />
                    <asp:BoundField DataField="vepSubtitle" HeaderText="ชื่อชิ้นส่วนหลัก"  />
                    <asp:BoundField DataField="vepRemark" HeaderText="คำอธิบาย"  />
                    <asp:TemplateField HeaderText="รูป" >
                        <ItemTemplate>
                            <asp:Image Height="250px" ImageUrl='<%# Eval("vepImage") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="vepFile" HeaderText="ไฟล์" />
                    <asp:TemplateField HeaderText="แก้ไข" >
                        <ItemTemplate>
                            <asp:Button id="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="คัดลอก" >
                        <ItemTemplate>
                            <asp:Button id="copyBtn" runat="server" Text="Copy" OnClick="copyBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ลบ" >
                        <ItemTemplate>
                            <asp:Button id="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
