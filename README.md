# **WPF Application with SQL Server**

This is a WPF-based desktop application that integrates with SQL Server for storing and displaying data. The project demonstrates a simple tab-based UI with data validation, input forms, and a data grid to display stored information.

---

## **Features**
- Easy-to-use input form for adding items.
- Validation for empty or invalid fields.
- Tabbed interface for input and viewing data.
- SQL Server integration for persistent storage.

---

### **1. Form Input Tab**
This tab provides a form to input item details like name, quantity, price, and description. Clicking the "Submit" button saves the data to the SQL Server database.

![image](https://github.com/user-attachments/assets/e26d8e61-bc24-4316-be4f-1e30ec414220)


---

### **2. Validation Error**
If any fields are left empty or contain invalid data, an error message is displayed to ensure proper input.

![image](https://github.com/user-attachments/assets/a64cdc4a-6a77-4b11-ac5c-34bbd9f99357)


---

### **3. Stored Data Tab**
The second tab displays all the stored items in a tabular format. This data is dynamically fetched from the SQL Server database.

![image](https://github.com/user-attachments/assets/9d5afbc2-ca8c-49e5-a796-c72251ba3145)


---

### **4. SQL Server View**
A snapshot of the SQL Server database shows how the data is structured and stored after being added via the WPF application.

![image](https://github.com/user-attachments/assets/ab50c49e-e820-426b-8408-17cc3fb41920)


---

## **Getting Started**

1. Clone this repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the solution in **Visual Studio**.
3. Update the connection string in `App.config` to match your SQL Server setup.
4. Build and run the application.

---

## **Technologies Used**
- **WPF**: For the user interface.
- **SQL Server**: For database storage.
- **.NET Framework**: Application framework.
- **ADO.NET**: For database communication.
