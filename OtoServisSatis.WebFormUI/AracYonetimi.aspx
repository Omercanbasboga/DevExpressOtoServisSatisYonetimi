<%@ Page Title="Araç Yönetimi" Language="C#" MasterPageFile="~/OtoServisSablon.Master" AutoEventWireup="true" CodeBehind="AracYonetimi.aspx.cs" Inherits="OtoServisSatis.WebFormUI.AracYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <asp:GridView ID="gvAraclar" runat="server" Height="136px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="343px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
     <h1>Araç Bilgileri</h1>
                    <table class="auto-style1">
                        <tr>
                            <td>Marka</td>
                            <td>
                                <asp:DropDownList ID="ddlMarkalar" runat="server" DataTextField="Adi" DataValueField="Id" TabIndex="1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Renk</td>
                            <td>
                                <asp:TextBox ID="txtRenk" runat="server" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Fiyatı</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtFiyati" runat="server" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFiyati" ErrorMessage="Boş Geçilemez!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Model</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txtModeli" runat="server" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Kasa Tipi</td>
                            <td>
                                <asp:TextBox ID="txtKasaTipi" runat="server" TabIndex="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Model Yılı</td>
                            <td>
                                <asp:TextBox ID="txtModelYili" runat="server" TabIndex="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModelYili" ErrorMessage="Boş Geçilemez!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Notlar</td>
                            <td>
                                <asp:TextBox ID="txtNotlar" runat="server" TabIndex="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="cbSatistaMi" runat="server" Text="Satışta mı?" TabIndex="8" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" TabIndex="9" />
                    &nbsp;
                    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" TabIndex="10" />
                    &nbsp;
                    <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" TabIndex="11" />


                            </td>
                        </tr>
                    </table>
<br />


                    <br />


</asp:Content>
