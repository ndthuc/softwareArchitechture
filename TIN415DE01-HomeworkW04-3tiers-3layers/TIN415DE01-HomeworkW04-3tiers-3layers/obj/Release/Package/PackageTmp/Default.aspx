<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TIN415DE01_HomeworkW04_3tiers_3layers.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Art Materials and Tools</legend>
            <div>
                <asp:Label ID="keywordLabel" runat="server" Text="Keyword "></asp:Label>
                <asp:TextBox ID="keywordTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="searchButton" runat="server" Text="SEARCH" OnClick="searchButton_Click" />
                <br />
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True"></asp:GridView>
            </div>
        </fieldset>
        <fieldset>
            <legend>Control</legend>
            <table>
                <%-- code --%>
                <tr>
                    <td>
                        <asp:Label ID="codeLabel" runat="server" Text="Code" Enabled="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="codeTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- name --%>
                <tr>
                    <td>
                        <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- category --%>
                <tr>
                    <td>
                        <asp:Label ID="categoryLabel" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="categoryTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- price --%>
                <tr>
                    <td>
                        <asp:Label ID="priceLabel" runat="server" Text="Price"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="priceTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- brand --%>
                <tr>
                    <td>
                        <asp:Label ID="brandLabel" runat="server" Text="Brand"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="brandTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Label ID="resultLabel" runat="server" Text="Result here"></asp:Label>
            <br />
            <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" />
            <asp:Button ID="updateButton" runat="server" Text="UPDATE" OnClick="updateButton_Click" />
            <asp:Button ID="deleteButton" runat="server" Text="DELETE" OnClick="deleteButton_Click"
                OnClientClick="return confirm('Are you sure?')" />
        </fieldset>

    </form>
</body>
</html>
