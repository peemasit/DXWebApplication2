<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TechnicianList.aspx.cs" Inherits="DXWebApplication2.TechnicianList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top:10px">
            <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" />
            <%--<dx:ASPxGridView ID="grid" runat="server" Theme="SoftOrange" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="tecId" Width="100%" 
                 OnCustomButtonCallback="grid_CustomButtonCallback" OnInitNewRow="grid_InitNewRow" on>
                <Columns>
                    
                    <dx:GridViewDataTextColumn FieldName="tecId" Caption="ID" ReadOnly="true">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn FieldName="tecCode" Caption="รหัสตำแหน่งงาน" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="tecSubtitle" Caption="ชื่อตำแหน่งงาน" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="tecHourRate" Caption="ค่าแรงต่อชั่วโมง" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="tecRemark" Caption="คำอธิบาย" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="tecActive"  Visible="false">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewCommandColumn ShowNewButton="true" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="5" ButtonRenderMode="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Clone">
                                <%--<Image ToolTip="Clone Record" Url="Images/clone.png" />--%>
                            <%--</dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                </Columns>
                <SettingsEditing EditFormColumnCount="3" />
        <SettingsPager Mode="ShowAllRecords" />
        <SettingsCommandButton>
            <NewButton RenderMode="Button"/>
            <EditButton RenderMode="Button" />
            <DeleteButton RenderMode="Button"/>
            <UpdateButton RenderMode="Button"/>
            <CancelButton RenderMode="Button"/>
        </SettingsCommandButton>
        <Styles>
            <CommandColumn Spacing="2px" Wrap="False" />
        </Styles>
    </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VehicleDatabaseConnectionString1 %>" SelectCommand="SELECT * FROM [tblTechnician] where tecActive = 1"></asp:SqlDataSource>--%>
            <asp:GridView ID="gvVehicle" runat="server"
                AutoGenerateColumns="false" Width="100%" >
                <Columns>
                    <asp:BoundField DataField="tecId" HeaderText="ID ตำแหน่ง"  />
                    <asp:BoundField DataField="tecCode" HeaderText="รหัสตำแหน่ง"  />
                    <asp:BoundField DataField="tecSubtitle" HeaderText="ชื่อตำแหน่ง"  />
                    <asp:BoundField DataField="tecHourRate" HeaderText="ค่าแรงต่อชั่วโมง" />
                    <asp:BoundField DataField="tecRemark" HeaderText="คำอธิบาย"  />
                    
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
                            <asp:Button id="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
