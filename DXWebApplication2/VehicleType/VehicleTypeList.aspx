<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="VehicleTypeList.aspx.cs" Inherits="DXWebApplication2.VehicleTypeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <%--<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="vetId" button>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="vetSubtitle" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vetImage" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vetRemark" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vetId" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn ShowNewButton="true" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="4" ButtonRenderMode="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Clone">
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                </Columns>
             <SettingsEditing EditFormColumnCount="3" />
             <SettingsPager Mode="ShowAllRecords" />
             <SettingsCommandButton>
                <NewButton RenderMode="Button"/>
                <EditButton RenderMode="Button"/>
                <DeleteButton RenderMode="Button"/>
                <UpdateButton RenderMode="Button"/>
                <CancelButton RenderMode="Button"/>
              </SettingsCommandButton>
                <Styles>
                    <CommandColumn Spacing="2px" Wrap="False" />--%>
           <%--     </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT [vetSubtitle], [vetImage], [vetRemark], [vetId] FROM [tblVehicleType]"></asp:SqlDataSource>
          --%>  <asp:GridView ID="gvVehicle" runat="server"
                AutoGenerateColumns="false" Width="100%" >
                <Columns>
                    <asp:BoundField DataField="vetId" HeaderText="ID ประเภทรถ"  />

                    <asp:BoundField DataField="vetSubtitle" HeaderText="ชื่อประเภทรถ"  />

                    <asp:BoundField DataField="vetRemark" HeaderText="คำอธิบาย"  />
                   
                    <asp:TemplateField HeaderText="รูป" >
                        <ItemTemplate>
                            <asp:Image Height="250px" ImageUrl='<%# Eval("vetImage") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                            <asp:Button id="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
