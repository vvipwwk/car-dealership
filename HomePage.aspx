<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CarDealership.HomePage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>CarImport.my · Find your next drive</title>
    <link rel="stylesheet" href="Site.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="site-header"><a class="brand-mark" href="HomePage.aspx">CarImport<span>.my</span></a><span class="welcome-text">Curated cars. A better way to buy.</span></header>
        <main class="site-body">
            <section class="hero">
                <div class="hero-content">
                    <span class="eyebrow">Your next chapter starts here</span>
                    <h1>Find the car that feels like yours.</h1>
                    <p>Explore our hand-picked vehicle line-up and get in touch with our team when you find the right fit.</p>
                    <div class="hero-actions">
                        <a class="btn" href="CustLogin.aspx">Customer sign in</a>
                        <a class="btn btn-secondary" href="StaffLogin.aspx">Staff sign in</a>
                    </div>
                </div>
            </section>
            <section class="feature-row" aria-label="Our service">
                <div class="feature-card"><strong>Selected vehicles</strong><span>A considered line-up of cars for every kind of drive.</span></div>
                <div class="feature-card"><strong>Clear details</strong><span>Review key specifications and pricing before you enquire.</span></div>
                <div class="feature-card"><strong>Personal support</strong><span>Our team is ready to help with your next step.</span></div>
            </section>
        </main>
        <footer class="site-footer">CarImport.my · Find your next drive</footer>
    </form>
</body>
</html>
