<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShopZone.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <div class="register">

        <div class="  register-top-grid">
            <h3>RESGISTER TO SHOPZONE</h3>
            <div class="mation">
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <label for="exampleInputEmail1">First Name</label>

                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtFirstName" placeholder="First Name"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regName" runat="server" 
       ControlToValidate="txtFirstName" 
       ValidationExpression="^[a-zA-Z'.\s]{1,50}"
       Text="Enter a valid name" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name is Required" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Last Name</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtLastName" placeholder="Last Name"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
       ControlToValidate="txtLastName" 
       ValidationExpression="^[a-zA-Z'.\s]{1,50}"
       Text="Enter a valid name" /> 
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="LastName is Required" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="exampleInputPassword1">Email Address</label>
                            <asp:TextBox runat="server" type="email" class="form-control" ID="txtEmailId" placeholder="Enter email"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
    ControlToValidate="txtEmailId" ErrorMessage="Required field cannot be left blank."
    Display="Dynamic">
</asp:RequiredFieldValidator>
 
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
    ErrorMessage="Invalid email address."    ControlToValidate="txtEmailId" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
    Display="Dynamic">
    </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputPassword1">Password</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtPassword" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputPassword1">Confirm Password</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtConfirmPassword" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                    </div>
                

                </div>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
    ErrorMessage="Passwords do not match."    ControlToCompare="txtPassword"
    ControlToValidate="txtConfirmPassword">
</asp:CompareValidator>

                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputPassword1">Security Question</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtSecurityQuestion" TextMode="SingleLine" placeholder="Security Question"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Security Question is Required " ControlToValidate="txtSecurityQuestion"></asp:RequiredFieldValidator>
                        </div>



                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputPassword1">Securiy Answer</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtSecurityAnswer" TextMode="SingleLine" placeholder="Security Answer"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Security Answer is Required " ControlToValidate="txtSecurityAnswer"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleTextarea">Address 1</label>
                            <asp:TextBox runat="server" type="text" class="form-control" Rows="3" ID="txtAddress1" placeholder="Address 1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter your valid Address " ControlToValidate="txtAddress1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleTextarea">Address 2</label>
                            <asp:TextBox runat="server" type="text" class="form-control" Rows="3" ID="txtAddress2" placeholder="Address 2(This is optional)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group">
                            <label for="exampleInputEmail1">City</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtCity" placeholder="City"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select your city" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-lg-6">

                        <div class="form-group">
                            <label for="exampleInputEmail1">Pincode</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtPincode" placeholder="Pincode"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                  ControlToValidate="txtPincode"
                  ValidationExpression="[0-9]{6}"
                  ErrorMessage="That is not a valid Pincode" />
                        </div>

                    </div>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="register-top-grid">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </div>
            <div class="clearfix"></div>


            <a class="news-letter" href="#">
                <label class="checkbox">
                    <input type="checkbox" name="checkbox" checked=""/><i> </i>Check if you agree
                </label>
            </a>
        </div>

        <div class="clearfix"></div>
        <div class="register-but">

            <asp:Button runat="server" ID="btnRegister" class="btn btn-primary" Text="Register" OnClick="btnRegister_Click" />

            <div class="clearfix"></div>

        </div>
    </div>
</asp:Content>
