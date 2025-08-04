# 🎓 Faculty Profile Management System

A comprehensive web application built using **ASP.NET Web Forms**, designed to manage academic and professional information of faculty members with ease. This project showcases essential ASP.NET capabilities, adheres to **N-tier architecture**, and integrates securely with a **Microsoft SQL Server** database using **C#**.

<img width="600" height="600" alt="image" src="https://github.com/user-attachments/assets/75002d7f-87cf-4fb1-b334-5e3c7e1b3406" />

<img width="1900" height="640" alt="image" src="https://github.com/user-attachments/assets/3373f583-480c-49d9-a7cb-dc01e8eeca38" />



---

## 📑 Table of Contents

* [✨ Key Features](#-key-features)
* [🛠️ Technology Stack](#️-technology-stack)
* [🏗️ System Architecture](#-system-architecture)
* [🚀 Getting Started](#-getting-started)

  * [🔧 Prerequisites](#-prerequisites)
  * [🗄️ Database Setup](#️-database-setup)
  * [⚙️ Installation](#️-installation)
* [🖱️ Usage](#️-usage)
* [📜 License](#-license)

---

## ✨ Key Features

* 🔐 **Secure Authentication**
  Login/logout functionality with session tracking. All pages are protected from unauthorized access.

* 🧾 **Faculty Profile Management**
  Create, update, and store detailed faculty records using a user-friendly form.

* 🗃️ **Persistent Data Storage**
  Profiles are saved in a secure SQL Server database, offering long-term storage.

* 🆔 **Auto-generated Employee ID**
  Unique IDs are generated dynamically using user initials and a system timestamp.

* ✅ **Robust Validation**
  Server-side checks ensure valid input for email, phone, and numeric fields.

* 🎨 **Consistent User Interface**
  A Master Page provides uniform layout and navigation across the application.

* 📍 **Active Navigation Highlighting**
  The navigation menu highlights the current page to enhance user orientation.

---

## 🛠️ Technology Stack

* **Frontend:** HTML, CSS
* **Backend:** C#
* **Framework:** ASP.NET Web Forms (.NET Framework 4.7.2)
* **Database:** Microsoft SQL Server
* **IDE:** Visual Studio 2022

---

## 🏗️ System Architecture

The system is structured using a **three-tier architecture** for better modularity and maintainability:

* **Presentation Layer (UI):**
  Includes `.aspx` pages like `Login.aspx`, `FacultyProfile.aspx`, and `Site.Master`. Handles user interface and inputs.

* **Business Logic Layer (BLL):**
  Written in `.aspx.cs` files. Manages form validation, event handling, and unique ID generation.

* **Data Access Layer (DAL):**
  Performs all database operations using `SqlConnection`, `SqlCommand`, and `SqlDataReader`.

* **Configuration:**
  The `Web.config` file stores application settings, including the connection string.

---

## 🚀 Getting Started

Follow these steps to run the project locally.

### 🔧 Prerequisites

Make sure the following tools are installed:

* Visual Studio 2022 (with **ASP.NET and Web Development** workload)
* Microsoft SQL Server (Express, Developer, or any edition)
* SQL Server Management Studio (SSMS)

---

### 🗄️ Database Setup

1. Open **SSMS** and connect to your SQL Server instance.
2. Create a new database named `FacultyDB`.
3. Open a new query window, select `FacultyDB`, and run the following SQL script:

```sql
CREATE TABLE [dbo].[FacultyProfiles] (
    [EmployeeID] [nvarchar](50) NOT NULL,
      NOT NULL,
      NOT NULL,
      NOT NULL,
      NULL,
      NOT NULL,
      NULL,
    [DateCreated] [datetime] NULL,
    CONSTRAINT [PK_FacultyProfiles] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

ALTER TABLE [dbo].[FacultyProfiles] ADD CONSTRAINT [UC_Email] UNIQUE ([Email]);

ALTER TABLE [dbo].[FacultyProfiles]
ADD CONSTRAINT [DF_FacultyProfiles_DateCreated] DEFAULT (GETDATE()) FOR [DateCreated];
```

4. Click **Execute** or press `F5` to run the script.

---

### ⚙️ Installation

1. Clone the repository:

```bash
git clone https://github.com/your-username/FacultyProfileManagementSystem.git
```

2. Open `FacultyProfileManagementSystem.sln` in **Visual Studio 2022**.

3. Update the connection string:

* Open `Web.config`.
* Find `FacultyDBConnectionString`.
* Update the `Data Source` with your SQL Server instance name, such as:
  `YOUR-PC\SQLEXPRESS` or `(localdb)\MSSQLLocalDB`.

4. Press `F5` or click **Start** to build and launch the application.

---

## 🖱️ Usage

1. On launch, you'll see the **Login Page**. Use the following credentials:

   * **Username:** `admin`
   * **Password:** `password123`

2. After login, you'll be redirected to the **Add Faculty Profile** page.

3. Fill in the faculty details and click **Submit** to save the profile to the database.

4. Use the **Logout** link to securely end your session.

---

## 📜 License

This project is licensed under the **MIT License**.
See the `LICENSE.md` file for more details.
