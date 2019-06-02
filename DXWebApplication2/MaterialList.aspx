<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="MaterialList.aspx.cs" Inherits="DXWebApplication2.MaterialList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <asp:GridView ID="gvVehicle" BorderWidth="1" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="matId" HeaderText="รหัสวัสดุ"  />
                    <asp:BoundField DataField="matSubtitle" HeaderText="ชื่อวัสดุ"  />
                    <asp:BoundField DataField="matRemark" HeaderText="คำอธิบาย"  />
                    <asp:TemplateField HeaderText="รูป" >
                        <ItemTemplate>
                            <asp:Image Height="250px" ImageUrl='<%# Eval("matImage") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="matFile" HeaderText="ไฟล์" />
                    <asp:BoundField DataField="matPrice" HeaderText="ราคา" />
                    <asp:TemplateField HeaderText="แก้ไช" >
                        <ItemTemplate>
                            <asp:Button id="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ลบ" >
                        <ItemTemplate>
                            <asp:Button id="deleteBtn" runat="server" Text="Delete" OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');" OnClick="deleteBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
