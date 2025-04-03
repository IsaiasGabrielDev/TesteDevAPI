## AuthController API Documentation

### **1. `GET /api/auth`**
- **Description**: Retrieves the authenticated user based on the email from the JWT token.
- **Authentication**: Requires a valid Bearer token.
- **Responses**:
  - `200 OK`: Returns the authenticated user's data.
  - `401 Unauthorized`: If the token is missing or invalid.
  - `404 Not Found`: If the user is not found.

---

### **2. `POST /api/auth/Login`**
- **Description**: Authenticates a user and returns a token.
- **Request Body (`JSON`)**:
  ```json
  {
    "email": "user@example.com",
    "password": "password123"
  }
  ```
- **Responses**:
  - `200 OK`: Returns an authentication token if login is successful.
  - `400 Bad Request`: If credentials are invalid.

---

### **3. `POST /api/auth/Register`**
- **Description**: Registers a new user.
- **Request Body (`JSON`)**:
  ```json
  {
    "name": "User Test",
    "email": "user@example.com",
    "password": "password123"
  }
  ```
- **Responses**:
  - `200 OK`: Returns the created user's data.
  - `400 Bad Request`: If there is an error during registration (e.g., email already exists).

---

## CategoryController API Documentation

### **1. `GET /api/category`**
- **Description**: Retrieves a specific category or a list of categories.
- **Authentication**: Requires a valid Bearer token.
- **Query Parameters**:
  - `categoryId` (int, optional): The ID of the category to retrieve.
- **Responses**:
  - `200 OK`: Returns a specific category if `categoryId` is provided, otherwise returns all categories.

---

### **2. `POST /api/category`**
- **Description**: Adds a new category.
- **Authentication**: Requires a valid Bearer token.
- **Request Body (`JSON`)**:
  ```json
  {
    "name": "Category Name"
  }
  ```
- **Responses**:
  - `200 OK`: Returns the created category.
  - `400 Bad Request`: If there is an error during category creation.

---

### **3. `PUT /api/category`**
- **Description**: Updates an existing category.
- **Authentication**: Requires a valid Bearer token.
- **Request Body (`JSON`)**:
  ```json
  {
    "id": 1,
    "name": "Updated Category Name"
  }
  ```
- **Responses**:
  - `200 OK`: Returns the updated category.
  - `400 Bad Request`: If there is an error during update.

---

### **4. `DELETE /api/category`**
- **Description**: Deletes a category.
- **Authentication**: Requires a valid Bearer token.
- **Query Parameters**:
  - `categoryId` (int, required): The ID of the category to delete.
- **Responses**:
  - `200 OK`: If the category is successfully deleted.
  - `400 Bad Request`: If there is an error during deletion.

---

## ProductController API Documentation

### **1. `GET /api/product`**
- **Description**: Retrieves a specific product or a paginated list of products.
- **Authentication**: Requires a valid Bearer token.
- **Query Parameters**:
  - `productId` (int, optional): The ID of the product to retrieve.
  - `pageNumber` (int, optional): The page number for pagination.
  - `pageSize` (int, optional): The number of items per page.
- **Responses**:
  - `200 OK`: Returns a specific product if `productId` is provided, otherwise returns paginated products.

---

### **2. `GET /api/product/stock`**
- **Description**: Retrieves a stock report of products.
- **Authentication**: Requires a valid Bearer token.
- **Responses**:
  - `200 OK`: Returns the stock report.
  - `400 Bad Request`: If an error occurs while retrieving the report.

---

### **3. `POST /api/product`**
- **Description**: Adds a new product.
- **Authentication**: Requires a valid Bearer token.
- **Request Body (`JSON`)**:
  ```json
  {
    "name": "Product Name",
    "price": 100.0
    "categoryId": 1
  }
  ```
- **Responses**:
  - `200 OK`: Returns the created product.
  - `400 Bad Request`: If there is an error during product creation.
  - `401 Unauthorized`: If the user is not authorized.

---

### **4. `PUT /api/product`**
- **Description**: Updates an existing product.
- **Authentication**: Requires a valid Bearer token.
- **Request Body (`JSON`)**:
  ```json
  {
    "id": 1,
    "name": "Product Name",
    "price": 100.0
    "categoryId": 1
  }
  ```
- **Responses**:
  - `200 OK`: Returns the updated product.
  - `400 Bad Request`: If there is an error during update.
  - `401 Unauthorized`: If the user is not authorized.

---

### **5. `DELETE /api/product`**
- **Description**: Deletes a product.
- **Authentication**: Requires a valid Bearer token.
- **Query Parameters**:
  - `productId` (int, required): The ID of the product to delete.
- **Responses**:
  - `200 OK`: If the product is successfully deleted.
  - `400 Bad Request`: If there is an error during deletion.
  
---

## ProductHistoryController API Documentation

### **1. `GET /api/producthistory`**
- **Description**: Retrieves the product history based on category and user.
- **Authentication**: Requires a valid Bearer token.
- **Query Parameters**:
  - `categoryId` (int, required): The ID of the category.
  - `userId` (int, required): The ID of the user.
- **Responses**:
  - `200 OK`: Returns the product history.
  - `400 Bad Request`: If an error occurs while retrieving the data.
