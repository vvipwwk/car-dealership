# ApexDrive Motors

A modern, responsive car dealership web application designed to provide an interactive vehicle showroom and dealership management experience.

**Live Demo:** [ApexDrive Motors](https://apexdrivemotor.netlify.app/)

---

## Overview

ApexDrive Motors is a browser-based car dealership platform built with HTML, CSS and JavaScript. It combines a customer-facing vehicle showroom with buyer services and an administrative management dashboard.

The application is designed to work without a build process and supports two operating modes: Local Preview Mode and Live Cloud Mode using Supabase.

## Features

### 🚗 Vehicle Showroom
- Browse available vehicles through an interactive showroom.
- Search vehicles by make and model.
- Filter by vehicle category, fuel type, availability and budget.
- Sort vehicles by price and model year.
- View detailed vehicle specifications.
- Explore vehicle images from multiple angles.
- Save favourite vehicles to a personal garage.
- Compare up to three vehicles side by side.

### 👤 Buyer Portal
- Buyer registration and authentication.
- Personalised buyer dashboard.
- Save and manage favourite vehicles.
- Schedule test-drive appointments.
- Vehicle purchase and financing calculator.
- Cash and financing payment options.
- Down payment and trade-in calculations.
- View bookings and purchase records.
- Manage personal profile information.

### 🛠️ Administration Dashboard
- Dealership overview and dashboard statistics.
- Vehicle inventory management.
- Add, edit and remove vehicle listings.
- Manage vehicle availability and reservation status.
- Manage test-drive bookings.
- View sales transactions.
- Manage registered buyers.
- Staff directory and HR management.
- Export inventory, sales and payroll reports in CSV format.

### 🎨 User Interface
- Responsive desktop and mobile layouts.
- Light and dark themes.
- Interactive showroom spotlight.
- Smooth animations and transitions.
- Modern dashboard and navigation interface.
- Multi-angle vehicle image gallery.

## Technology Stack

| Technology | Purpose |
|---|---|
| HTML5 | Application structure |
| CSS3 | Styling, layouts and responsive design |
| JavaScript | Application logic and interactions |
| Supabase | Optional authentication and cloud database |
| PostgreSQL | Cloud data storage |
| Supabase Realtime | Live data synchronisation |
| Google Fonts | Typography |
| LocalStorage | Local application data persistence |
| SessionStorage | Local session persistence |

## Project Structure

```text
car-dealership/
│
└── docs/
    ├── index.html       # Main application
    └── cursor.png       # Custom cursor asset
```

The application is built as a single HTML file containing its CSS and JavaScript. No additional frontend framework or build tooling is required.

## Getting Started

### Option 1: Run Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/vvipwwk/car-dealership.git
   ```

2. Navigate into the project directory:

   ```bash
   cd car-dealership
   ```

3. Open the application:

   ```text
   docs/index.html
   ```

4. Open the file using your preferred modern web browser.

No additional installation or build process is required for Local Preview Mode.

### Option 2: GitHub Pages

The application can be hosted directly using GitHub Pages.

1. Open the repository on GitHub.
2. Navigate to **Settings → Pages**.
3. Under Build and deployment, select **Deploy from a branch**.
4. Select the `main` branch.
5. Select `/docs` as the publishing directory.
6. Save the configuration.

GitHub Pages will publish the application using the contents of the `docs` directory.

## Application Modes

| Mode | Description |
|---|---|
| Local Preview Mode | Uses browser LocalStorage and SessionStorage to maintain demo data and sessions. |
| Live Cloud Mode | Uses Supabase Authentication, PostgreSQL and Realtime for shared application data. |

Local Preview Mode works without any external database configuration.

### Supabase Integration

To enable Live Cloud Mode:

1. Create a Supabase project.
2. Configure the required database tables:
   - `profiles`
   - `vehicles`
   - `bookings`
   - `sales`
   - `saved_vehicles`
3. Configure the required database function for vehicle purchases.
4. Enable Row Level Security (RLS) and configure appropriate access policies.
5. Enable Realtime for the required tables.
6. Configure the Supabase project URL and public anon key in the `SUPABASE_CONFIG` section of `docs/index.html`.

**Security Notice:** Never expose your Supabase `service_role` key in frontend code. Use only the public anon key with correctly configured RLS policies.

## Demo Access

The application includes demonstration accounts and sample dealership data in Local Preview Mode.

Refer to the application login interface for the available demo login options.

Use the **Reset Demo Data** option to restore the original sample data.

## Important Notes

- Local Preview Mode is intended for demonstration and testing purposes.
- Browser-stored credentials and data do not provide production-grade security.
- Live Cloud Mode requires correctly configured Supabase authentication and database security policies.
- Staff and HR records are currently maintained as demonstration data rather than synchronised cloud records.
- The application requires an internet connection for external resources such as Google Fonts and Supabase services.

## License

No license has been specified for this project yet.
