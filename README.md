# Hướng dẫn chạy dự án Test 2 sử dụng Visual Studio

## 1. Cài đặt môi trường

Đảm bảo bạn đã cài đặt các phần mềm sau trước khi chạy dự án:
- [Visual Studio](https://visualstudio.microsoft.com/): IDE cho việc phát triển ứng dụng .NET.
- [Node.js](https://nodejs.org/): Để chạy mã JavaScript trong dự án ReactJS.

## 2. Cài đặt Database

Dự án này sử dụng SQL Server làm cơ sở dữ liệu. Bạn cần tải xuống tệp instnwnd.sql từ [GitHub](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql) và thực thi tệp script này trong SQL Server để tạo cơ sở dữ liệu.

## 3. Thiết lập kết nối với cơ sở dữ liệu

Sau khi tạo cơ sở dữ liệu, bạn cần chỉnh sửa tệp appsettings.json trong thư mục Test_2.Server để cấu hình kết nối với cơ sở dữ liệu. 

Mở tệp `appsettings.json` và sửa các thông số sau:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your_server>;Database=<your_database>;User Id=<your_user_id>;Password=<your_password>;"
  }
}
Thay thế <your_server>, <your_database>, <your_user_id>, và <your_password> bằng thông tin kết nối của bạn.
```

## 4. Mở dự án trong Visual Studio
Mở thư mục dự án bằng Visual Studio bằng cách chọn File > Open > Project/Solution và chọn tệp .sln tương ứng.

## 5. Chạy dự án
Đảm bảo rằng dự án Back-End (Test_2.Server) được đặt làm dự án khởi đầu (startup project).
Nhấn Ctrl + F5 hoặc chọn Debug > Start Without Debugging để chạy dự án.
## 6. Truy cập ứng dụng
Mở trình duyệt web và truy cập vào địa chỉ http://localhost:<port> để sử dụng ứng dụng. Thay <port> bằng cổng mà dự án được chạy trên (thường là 5000 cho dự án .NET Core).

## 7. Thực hiện các chức năng
Sau khi truy cập vào ứng dụng, bạn có thể sử dụng các chức năng như tìm kiếm (theo Id, Name) và sắp xếp (theo Id, Name,...) để thao tác với danh sách khách hàng hiển thị trên giao diện.
Hãy đảm bảo rằng bạn đã thay đổi các giá trị `<your_server>`, `<your_database>`, `<your_user_id>`, và `<your_password>` trong tệp `appsettings.json` thành thông tin kết nối thực của bạn.
