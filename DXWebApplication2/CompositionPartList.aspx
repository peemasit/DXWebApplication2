<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="CompositionPartList.aspx.cs" Inherits="DXWebApplication2.CompositionPartList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <asp:GridView ID="gvVehicle" BorderWidth="1" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="copId" HeaderText="รหัสส่วนประกอบ"  />
                    <asp:BoundField DataField="copSubtitle" HeaderText="ชื่อส่วนประกอบรถ"  />
                    <asp:BoundField DataField="copRemark" HeaderText="คำอธิบาย"  />
                    <asp:TemplateField HeaderText="รูป" >
                        <ItemTemplate>
                            <asp:Image Height="250px" ImageUrl='<%# Eval("copImage") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="copFile" HeaderText="ไฟล์" />
                    <asp:BoundField DataField="vepId" HeaderText="รหัสรุ่นรถ" />
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
