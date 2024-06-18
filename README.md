Enum Convertor API
This project provides an ASP.NET Core API that retrieves enum type values and their associated names from a specified assembly. It's a useful tool for applications that need to dynamically access and use enum values.

Features
Get Enum Type: Retrieve the type information of an enum by its name.
Get Enum Values and Names: Retrieve a dictionary of enum values and their corresponding names.
RESTful API: Provides endpoints to interact with enums through HTTP requests.
Endpoints
Get All Enum Values and Names
Retrieve a dictionary of all values and names for a specified enum type.

URL: /api/{enumName}

Method: GET

URL Parameter:

enumName (string): The name of the enum type.
Response:

200 OK: Returns a dictionary where the key is the enum name (in lowercase) and the value is the corresponding integer value.
400 Bad Request: If the enum type is not found or an error occurs, returns a bad request status with an error message.
Usage
To use this API, follow the steps below:

Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/EnumConvertorAPI.git
cd EnumConvertorAPI
Build and run the application
