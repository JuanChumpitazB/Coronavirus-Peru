<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Presentacion.CoronavirusPeru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../css/bootstrap.css" rel="stylesheet" />
    <asp:Label ID="lbl1" runat="server"></asp:Label>
    <br />
    <br />
    <div class="">
        <div class="col-sm-12 overflow-auto w-100">
            <%-- <asp:RadioButton ID="rbtInfectados" runat="server" GroupName="chart1" Text="General     " CssClass="font-weight-bold" OnCheckedChanged="rbtInfectadosChanged" />
            <asp:RadioButton ID="rbtInfectadosxDia" runat="server" GroupName="chart1" Text="Infectados x Dia" CssClass="font-weight-bold" OnCheckedChanged="rbtInfectadosxDiaChanged" />--%>

            <asp:Button ID="btnGeneral" runat="server" Text="General" CssClass="btn btn-dark" OnClick="btnGeneral_Click" />
            <asp:Button ID="btnInfectadosXdia" runat="server" Text="Infectados por dia" CssClass="btn btn-primary" OnClick="btnInfectadosXdia_Click" />

            <%-- <asp:Button ID="btnMostrar1" runat="server" Text="Mostrar" CssClass="btn btn-info" OnClick="btnMostrar1_Click" />--%>
        </div>

        <div class="col-sm-12 overflow-auto w-100">
            <asp:chart ID="Chart_G1" runat="server" Width="4000px" Height="400px" CssClass="table  table-bordered table-condensed table-responsive">
                <%--<Series>
                    <asp:Series Name="Infectados" XValueMember="0" YValueMembers="1" ChartType="Line" Color="Blue" YValuesPerPoint="4"></asp:Series>
                    <asp:Series Name="Fallecidos" XValueMember="0" YValueMembers="2" ChartType="Line" Color="Red" YValuesPerPoint="4"></asp:Series>
                    <asp:Series Name="Recuperados" XValueMember="0" YValueMembers="3" ChartType="Line" Color="Green" YValuesPerPoint="4"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>--%>
            </asp:chart>
        </div>
        <br />




        <div class="form-inline">
            <div class="col-sm-2"></div>
            <div class="col-sm-1"></div>
            <div class="col-sm-2 align-content-center">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl" runat="server" Text="Mortalidad" ForeColor="Black" Font-Bold="true" Font-Size="30px" padding="20px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="p-3 bg-danger align-content-center">
                                <asp:Label ID="lblMortalidad" runat="server" BackColor="#dc3545" ForeColor="White" Font-Bold="true" Font-Size="30px" padding="20px" />
                            </p>
                        </td>
                    </tr>
                </table>
            </div>


            <div class="col-sm-2"></div>
            <div class="col-sm-1"></div>
            <div class="col-sm-2 align-content-center">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Infectados" ForeColor="Black" Font-Bold="true" Font-Size="30px" padding="20px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="p-3 bg-warning align-content-center">
                                <asp:Label ID="lblIndectados" runat="server" BackColor="#ffc107" ForeColor="Black" Font-Bold="true" Font-Size="30px" padding="20px" />
                            </p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />

    <div class="col-sm-12 overflow-auto w-100">
        <%--<asp:RadioButton ID="rbtPruebas" runat="server" GroupName="chart2" Text="Pruebas - Casos Activos     " CssClass="font-weight-bold" />
            <asp:RadioButton ID="rbtActivos" runat="server" GroupName="chart2" Text="Activos - Hospitalizados - UCI" CssClass="font-weight-bold" />

            <asp:Button ID="btnMostrar2" runat="server" Text="Mostrar" CssClass="btn btn-info" OnClick="btnMostrar2_Click" />--%>

        <asp:Button ID="btnPruebas" runat="server" Text="Pruebas" CssClass="btn btn-dark" OnClick="btnPruebas_Click"  />
        <asp:Button ID="btnActivos" runat="server" Text="Activos - Hospitalizados - UCI" CssClass="btn btn-danger" OnClick="btnActivos_Click" />

    </div>
    <br />
    <div class="">
        <div class="col-sm-12 overflow-auto w-100">
            <asp:Chart ID="Chart_G2" runat="server" Width="4000px" Height="400px">
                <%--<Series>
                    <asp:Series Name="Infectados" XValueMember="0" YValueMembers="1" ChartType="Line" Color="Blue" YValuesPerPoint="4"></asp:Series>
                    <asp:Series Name="Fallecidos" XValueMember="0" YValueMembers="2" ChartType="Line" Color="Red" YValuesPerPoint="4"></asp:Series>
                    <asp:Series Name="Recuperados" XValueMember="0" YValueMembers="3" ChartType="Line" Color="Green" YValuesPerPoint="4"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>--%>
            </asp:Chart>
        </div>
        <br />
    </div>


    <asp:Label ID="lblIndicadorChart1" runat="server" Visible="false"></asp:Label>


</asp:Content>
