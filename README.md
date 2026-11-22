# Car Dealership

A car dealership web application built twice, in two different stacks, inside one repository:

| | Version | Location | Stack | Brand |
|---|---|---|---|---|
| 1 | **ASP.NET Web Forms app** (original) | repo root | C#, .NET Framework 4.8, SQL Server | CarImport.my |
| 2 | **HTML rebuild** (new) | [`docs/index.html`](docs/index.html) | Single-file HTML/CSS/JavaScript, optional Supabase backend | ApexDrive Motors |

**🚀 Live demo (ApexDrive Motors):** [apexdrivemotor.netlify.app](https://apexdrivemotor.netlify.app/)

The original app was built as a learning project based on research of an existing on-premises car dealership website. The rebuild re-imagines the same idea as a modern, single-page web app that runs entirely in the browser and can be hosted on GitHub Pages.

---

## 1. ApexDrive Motors – HTML rebuild (`docs/index.html`)

A single-file, no-build-step single-page application: showroom, test-drive booking, financing calculator, buyer portal and an admin console.

### Two run modes

| Mode | How it works |
|---|---|
| **Local Preview Mode** (default) | All data lives in the browser (`localStorage`/`sessionStorage`) and is seeded with demo vehicles, buyers, bookings and a sample sale. No setup needed. |
| **Live Cloud Mode** | If a Supabase URL and anon key are set in `index.html`, the app uses Supabase Auth, Postgres tables and Realtime so multiple users share the same live inventory and bookings. |

A banner at the top of the page shows which mode is active.

### Features

**Public showroom**
- Hero section with an auto-rotating "Showroom Spotlight" carousel
- Category quick-filters (Sedan, SUV, Coupe, Electric)
- Vehicle grid with search, body/fuel/status filters, max-budget filter and sorting (newest, price low→high, high→low)
- Vehicle detail page with specs, VIN, studio colour-finish preview and flip-angle toggle
- Save vehicles to a **Saved Garage**
- **Side-by-side comparison** of up to 3 vehicles, including an estimated monthly payment

**Buyer portal**
- Register / sign in (demo buyer: `daniel.tan@example.com`, any password, in local mode)
- Book a **test drive** (date, time slot, branch, notes) with double-booking protection
- **Purchase and financing checkout**: auto loan (3.5% APR, 36–72 months) or full cash, down payment, trade-in allowance and live monthly-instalment estimate
- "My Bookings & Orders" page with cancellation and printable purchase receipts
- Editable buyer profile

**Admin (Master Admin) console**
- Dashboard, inventory management, bookings and sales, buyer list, and an HR and staff view
- Access restricted to a single Master Admin account

### Quick start

1. Visit the live site at [apexdrivemotor.netlify.app](https://apexdrivemotor.netlify.app/), or open `docs/index.html` locally in a browser. To host your own copy, drag the `docs/` folder into [Netlify](https://www.netlify.com/) or enable **GitHub Pages** (Settings → Pages → Deploy from branch → `main` / `/docs`).
2. Click **Demo Buyer Account** or **Buyer Sign In** to explore as a customer.
3. Use **Staff Admin Login** in the footer for the admin console.
   - Local mode default: `admin@apexdrive.com` / `admin123`, or the **1-Click Master Admin Demo** button.
4. Use **Reset Demo Data** in the footer to restore the sample data.

### Enabling Live Cloud Mode (Supabase)

1. Create a [Supabase](https://supabase.com) project.
2. Create the tables the app reads and writes:
   `profiles`, `vehicles`, `bookings`, `sales`, `saved_vehicles`
   plus a Postgres function `complete_vehicle_purchase(p_vehicle_id, p_payment_method, p_down_payment, p_trade_in, p_monthly_installment)` that records the sale and marks the vehicle as sold.
3. Enable **Row Level Security (RLS)** on every table and write policies so buyers can only access their own bookings, sales and saved vehicles, and only the admin profile (`portal_role = 'staff'`) can manage inventory.
4. Turn on Realtime for `vehicles`, `bookings` and `sales`.
5. Set your project URL and **anon** key in the `SUPABASE_CONFIG` block near the top of the `<script>` in `docs/index.html`.

> ⚠️ Only ever put the **anon (public)** key in front-end code, never the `service_role` key. The anon key is safe to expose only when RLS is correctly configured.

### Tech notes

- Vanilla JavaScript with a small hash-less view router (`navigate()` → `render()`); no framework or build tooling
- Inline SVG car illustrations are used when a vehicle has no image URL
- Google Fonts (Inter, Plus Jakarta Sans); responsive layout, reduced-motion support and print styles for receipts
- All user-supplied text is HTML-escaped before rendering

---

## 2. CarImport.my – ASP.NET Web Forms app (repo root)

The original implementation: a role-based dealership site with separate **customer** and **staff** portals backed by SQL Server.

### Features

| Portal | Capabilities | Pages |
|---|---|---|
| Landing | Choose customer or staff entry | `HomePage.aspx` |
| Customer | Register, log in (with "Remember Me"), browse vehicle line-up, view details and image, book a car | `CustReg`, `CustLogin`, `CustHome`, `CVehicles`, `CVehicleDetails`, `BuyCar`, `BookCar` |
| Staff | Log in, add/list/remove vehicles, add/edit vehicle details with image upload (`.jpg`/`.png`), manage customers and staff, view booking records | `StaffLogin`, `StaffHome`, `SVehicleAdd`, `SVehicles`, `SVehicleRemove`, `SDetails`, `SVehicleDetailEdit`, `SCustomer*`, `StaffReg`, `SStaff*`, `HR`, `BookRecord` |

Each portal has its own master page (`NavigationCust.Master`, `NavigationStaff.Master`) with a `TreeView` menu driven by `web.sitemap` (customer) or `Web1.sitemap` (staff). Pages check `Session["username"]` or `Session["staffid"]` and redirect to login when it is missing.

### Tech stack

- C#, ASP.NET Web Forms, .NET Framework 4.8
- SQL Server / SQL Server Express (database `CarDealer`), ADO.NET (`System.Data.SqlClient`)
- Visual Studio 2022, IIS Express
- NuGet: `Microsoft.CodeDom.Providers.DotNetCompilerPlatform` 2.0.1

### Database schema

The code expects a database named **`CarDealer`**. Column order matters because several `INSERT` statements don't list column names.

| Table | Columns (in order) |
|---|---|
| `CarLists` | `cid` (PK), `brand`, `model`, `type`, `engine`, `country`, `price` |
| `CarDetail` | `did` (PK), `cid`, `brand`, `model`, `description`, `img` |
| `Customer` | `uid` (identity PK), `username`, `password`, `fullname`, `DOB`, `sex`, `contactno`, `email` |
| `Staff` | `StaffID` (PK), `staffname`, `password`, `fullname`, `DOB`, `sex`, `position`, `contactno`, `email` |
| `Sale` | `salesid`, `brand`, `model`, `price`, `buyer` |

```sql
CREATE DATABASE CarDealer;
GO
USE CarDealer;
GO

CREATE TABLE dbo.CarLists (
    cid VARCHAR(20) PRIMARY KEY, brand VARCHAR(50) NOT NULL, model VARCHAR(50) NOT NULL,
    type VARCHAR(30) NOT NULL, engine VARCHAR(50) NOT NULL, country VARCHAR(50) NOT NULL,
    price DECIMAL(12,2) NOT NULL
);
CREATE TABLE dbo.CarDetail (
    did VARCHAR(20) PRIMARY KEY, cid VARCHAR(20) NOT NULL REFERENCES dbo.CarLists(cid),
    brand VARCHAR(50) NOT NULL, model VARCHAR(50) NOT NULL,
    description VARCHAR(MAX), img VARCHAR(255)
);
CREATE TABLE dbo.Customer (
    uid INT IDENTITY(1,1) PRIMARY KEY, username VARCHAR(50) NOT NULL, password VARCHAR(100) NOT NULL,
    fullname VARCHAR(100) NOT NULL, DOB DATE NOT NULL, sex VARCHAR(10) NOT NULL,
    contactno VARCHAR(20) NOT NULL, email VARCHAR(100) NOT NULL
);
CREATE TABLE dbo.Staff (
    StaffID VARCHAR(20) PRIMARY KEY, staffname VARCHAR(50) NOT NULL, password VARCHAR(100) NOT NULL,
    fullname VARCHAR(100) NOT NULL, DOB DATE NOT NULL, sex VARCHAR(10) NOT NULL,
    position VARCHAR(30) NOT NULL, contactno VARCHAR(20) NOT NULL, email VARCHAR(100) NOT NULL
);
CREATE TABLE dbo.Sale (
    salesid VARCHAR(10) PRIMARY KEY, brand VARCHAR(50), model VARCHAR(50),
    price VARCHAR(30), buyer VARCHAR(50)
);

-- Seed a staff account so you can log in to the staff portal
INSERT INTO dbo.Staff VALUES
('S001','admin','admin12345','Admin User','1990-01-01','Male','Manager','0123456789','admin@carimport.my');
```

### Running it

1. Install **Visual Studio 2022** (ASP.NET workload), the **.NET Framework 4.8** developer pack and **SQL Server Express**.
2. Clone the repo and create the `CarDealer` database with the script above.
3. Replace the hard-coded connection string `Data Source=DELL-LATITUDE-5\SQLEXPRESS;...` with your own instance (e.g. `.\SQLEXPRESS`) in each `*.aspx.cs` file that creates a `SqlConnection`.
4. Make sure the `img/` folder exists (vehicle image uploads are saved there).
5. Open `CarDealership.sln`, restore NuGet packages and press **F5**. The start page is `HomePage.aspx`.

---

## Repository layout

```
car-dealership/
├── docs/
│   └── index.html            # ApexDrive Motors – HTML rebuild (GitHub Pages ready)
├── *.aspx / *.aspx.cs        # CarImport.my – ASP.NET pages and code-behind
├── NavigationCust.Master     # Customer master page
├── NavigationStaff.Master    # Staff master page
├── web.sitemap, Web1.sitemap # Customer / staff navigation
├── Web.config                # ASP.NET configuration
├── CarDealership.sln / .csproj
├── img/                      # Uploaded vehicle images
├── Properties/, packages/    # Project support files
└── customer.png, dealer.png  # Landing-page images
```

---

## Known limitations

**ASP.NET app (learning project, not production-ready)**
- Most SQL is built by string concatenation, so it is vulnerable to SQL injection; use parameterised queries (already done in `CustReg` and `StaffReg`).
- Passwords are stored in plain text, and "Remember Me" stores the password in a cookie.
- The connection string is hard-coded in every code-behind file instead of `Web.config`.
- Log out does not clear the session, and staff roles are not enforced.
- `BuyCar` looks up the last customer's `uid` rather than the logged-in user, and a booking doesn't mark the car unavailable.

**HTML rebuild**
- In Local Preview Mode, data and the admin credentials are client-side only, so it is a demo and not real security.
- In Live Cloud Mode, security depends entirely on correct Supabase RLS policies.
- HR and staff records are demo data; they are not synced to Supabase.

---

## License

No licence specified yet. Add a `LICENSE` file (e.g. MIT) if you want others to reuse the code.
