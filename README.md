donet ef add migration migrationName
dotnet ef update database (mặc định tạo 2 account (admin@example.com : 123 và user@example.com : 123 ))

API nào muốn có quyền admin thì cho [Authorize(Policy = "AdminOnly")] lên trên hàm đó trong controller 
API nào muốn có quyền user thì cho [Authorize(Policy = "UserOnly")] lên trên hàm đó trong controller 
API nào k muốn có quyền (public tất cả thì không cần thêm)
