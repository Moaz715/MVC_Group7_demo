# Define paths
$resxPath = "C:\Users\hp\source\repos\MVC_Group7_demo\MVC_Group7_demo_PLL\Resource\SharedResources.resx"
$arabicResxPath = "C:\Users\hp\source\repos\MVC_Group7_demo\MVC_Group7_demo_PLL\Resource\SharedResources.ar-EG.resx"

# Define keys and values
$names = @(
    "FinalizeOrderError", "FinalizeOrderSuccess", "GetAll.Contains", "GetAll.Delete", "GetAll.Details",
    "GetAll.Edit", "GetAll.Header", "GetAll.NoCategories", "GetAll.Products", "GetAll.SubHeader",
    "GetAll.Title", "GetAll.ViewProducts", "LoginRequiredError", "newLayout.About", "newLayout.AllProducts",
    "newLayout.Categories", "newLayout.Home", "newLayout.Login", "newLayout.Logout", "newLayout.MyProfile",
    "newLayout.NavbarBrand", "newLayout.SearchButton", "newLayout.SearchPlaceholder", "newLayout.Shop",
    "newLayout.SiteTitle", "newLayout.ViewOrder", "NotFoundError", "Success", "SuccessMessage", "ErrorMessage",
    "SignUp.Header", "SignUp.NameLabel", "SignUp.EmailLabel", "SignUp.PasswordLabel", "SignUp.PhoneLabel",
    "SignUp.LocationLabel", "SignUp.SubmitButton", "Login.Header", "Login.EmailLabel", "Login.PasswordLabel",
    "Login.RememberMe", "Category.Details.Title", "Category.ProductsLabel", "Category.NoProducts",
    "Category.BackButton", "Category.EditButton", "Category.DeleteButton", "Category.ProductCount",
    "Category.DetailsButton", "Shop.Header.Title", "Shop.Header.Subtitle", "Shop.SearchResults",
    "Shop.NoProducts.Title", "Shop.NoProducts.Message", "Shop.LowStock", "Shop.OutOfStock",
    "Shop.StockLabel", "Shop.AddToOrder", "Shop.OutOfStockButton", "Profile.Header", "Profile.UsernameLabel",
    "Profile.EmailLabel", "Profile.BackButton", "Profile.ViewOrdersButton", "Profile.EditButton",
    "Order.Current.Title", "Order.NoActiveOrder", "Order.TotalPriceLabel", "Order.ItemCountLabel",
    "Order.ProductColumn", "Order.ImageColumn", "Order.QuantityColumn", "Order.UnitPriceColumn",
    "Order.SubtotalColumn", "Order.BackButton", "Order.DeleteButton", "Order.DeleteConfirm",
    "Order.EditButton", "Order.CheckoutButton", "Payment.Title", "Payment.CardNumberLabel",
    "Payment.CardNumberPlaceholder", "Payment.CardholderLabel", "Payment.CardholderPlaceholder",
    "Payment.ExpirationLabel", "Payment.ExpirationPlaceholder", "Payment.CVVLabel",
    "Payment.CardNumberValidation", "Payment.CardholderValidation", "Payment.ExpirationValidation",
    "Payment.CVVValidation", "Payment.ChooseTitle", "Payment.ChooseDescription", "Payment.CardButton",
    "Payment.CashButton", "Order.Edit.Title", "Order.ApplyChangesButton", "Order.RemoveColumn",
    "Order.Finalized.Title", "Order.TotalPriceColumn", "Order.ItemCountColumn", "Order.LocationColumn",
    "Order.DeliveryNameColumn", "Order.FinalizedOnColumn", "Order.PaymentMethodColumn",
    "Order.ActionsColumn", "Order.ViewButton", "Order.CancelButton", "Product.PriceLabel",
    "Product.StockLabel", "Product.DescriptionLabel", "Product.BackButton", "Product.FilterLabel",
    "Product.AllFilter", "Product.FruitsFilter", "Product.VegetablesFilter", "Product.NoProducts",
    "Product.DetailsButton", "newLayout.PopularItems", "newLayout.NewArrivals"
)

$englishValues = @{
    "FinalizeOrderError" = "Failed to finalize order."
    "FinalizeOrderSuccess" = "Your order has been finalized successfully!"
    "GetAll.Contains" = "Contains"
    "GetAll.Delete" = "Delete"
    "GetAll.Details" = "Details"
    "GetAll.Edit" = "Edit"
    "GetAll.Header" = "Explore Our Categories"
    "GetAll.NoCategories" = "No categories found."
    "GetAll.Products" = "Products"
    "GetAll.SubHeader" = "Discover a variety of products organized by category."
    "GetAll.Title" = "All Categories"
    "GetAll.ViewProducts" = "View Products"
    "LoginRequiredError" = "You must be logged in to perform this action."
    "newLayout.About" = "About"
    "newLayout.AllProducts" = "All Products"
    "newLayout.Categories" = "Categories"
    "newLayout.Home" = "Home"
    "newLayout.Login" = "Login"
    "newLayout.Logout" = "Logout"
    "newLayout.MyProfile" = "My Profile"
    "newLayout.NavbarBrand" = "My Shop"
    "newLayout.SearchButton" = "Search"
    "newLayout.SearchPlaceholder" = "Search products..."
    "newLayout.Shop" = "Shop"
    "newLayout.SiteTitle" = "Shop"
    "newLayout.ViewOrder" = "View Order"
    "NotFoundError" = "Item not found."
    "Success" = "Product added to order!"
    "SuccessMessage" = "Operation completed successfully!"
    "ErrorMessage" = "An error occurred."
    "SignUp.Header" = "Sign Up"
    "SignUp.NameLabel" = "Name"
    "SignUp.EmailLabel" = "Email"
    "SignUp.PasswordLabel" = "Password"
    "SignUp.PhoneLabel" = "PhoneNumber"
    "SignUp.LocationLabel" = "Location"
    "SignUp.SubmitButton" = "Submit"
    "Login.Header" = "Log In"
    "Login.EmailLabel" = "Email"
    "Login.PasswordLabel" = "Password"
    "Login.RememberMe" = "Remember me"
    "Category.Details.Title" = "Category Details"
    "Category.ProductsLabel" = "Products:"
    "Category.NoProducts" = "No products in this category."
    "Category.BackButton" = "Back to List"
    "Category.EditButton" = "Edit"
    "Category.DeleteButton" = "Delete"
    "Category.ProductCount" = "Contains"
    "Category.DetailsButton" = "Details"
    "Shop.Header.Title" = "Shop in style"
    "Shop.Header.Subtitle" = "Browse our amazing products"
    "Shop.SearchResults" = "Showing results for:"
    "Shop.NoProducts.Title" = "No products available at the moment."
    "Shop.NoProducts.Message" = "Please check back later!"
    "Shop.LowStock" = "Low Stock"
    "Shop.OutOfStock" = "Out of Stock"
    "Shop.StockLabel" = "Stock:"
    "Shop.AddToOrder" = "Add to Order"
    "Shop.OutOfStockButton" = "Out of Stock"
    "Profile.Header" = "My Profile"
    "Profile.UsernameLabel" = "Username"
    "Profile.EmailLabel" = "Email"
    "Profile.BackButton" = "Back to Home"
    "Profile.ViewOrdersButton" = "View Orders"
    "Profile.EditButton" = "Edit Profile"
    "Order.Current.Title" = "My Current Order"
    "Order.NoActiveOrder" = "You don’t have any active orders."
    "Order.TotalPriceLabel" = "Total Price:"
    "Order.ItemCountLabel" = "Number of Items:"
    "Order.ProductColumn" = "Product"
    "Order.ImageColumn" = "Image"
    "Order.QuantityColumn" = "Quantity"
    "Order.UnitPriceColumn" = "Unit Price"
    "Order.SubtotalColumn" = "Subtotal"
    "Order.BackButton" = "Back"
    "Order.DeleteButton" = "Delete Order"
    "Order.DeleteConfirm" = "Are you sure you want to delete this order?"
    "Order.EditButton" = "Edit Order"
    "Order.CheckoutButton" = "Checkout"
    "Payment.Title" = "Material Design for Bootstrap"
    "Payment.CardNumberLabel" = "Card Number"
    "Payment.CardNumberPlaceholder" = "1234 5678 9012 3457"
    "Payment.CardholderLabel" = "Cardholder's Name"
    "Payment.CardholderPlaceholder" = "Cardholder's Name"
    "Payment.ExpirationLabel" = "Expiration"
    "Payment.ExpirationPlaceholder" = "MM/YYYY"
    "Payment.CVVLabel" = "CVV"
    "Payment.CardNumberValidation" = "Please enter a 16-digit card number in the format: 1234 5678 9012 3456"
    "Payment.CardholderValidation" = "Name can only contain letters and spaces."
    "Payment.ExpirationValidation" = "Please enter a valid expiration date in MM/YYYY format."
    "Payment.CVVValidation" = "CVV must be exactly 3 digits."
    "Payment.ChooseTitle" = "Choose Your Payment Method"
    "Payment.ChooseDescription" = "Please select how you’d like to pay for your order."
    "Payment.CardButton" = "Pay with Card"
    "Payment.CashButton" = "Pay with Cash"
    "Order.Edit.Title" = "Edit Your Order"
    "Order.ApplyChangesButton" = "Apply Changes"
    "Order.RemoveColumn" = "Remove"
    "Order.Finalized.Title" = "Finalized Orders"
    "Order.TotalPriceColumn" = "Total Price"
    "Order.ItemCountColumn" = "Number of Items"
    "Order.LocationColumn" = "Customer Location"
    "Order.DeliveryNameColumn" = "Delivery Name"
    "Order.FinalizedOnColumn" = "Finalized On"
    "Order.PaymentMethodColumn" = "Payment Method"
    "Order.ActionsColumn" = "Actions"
    "Order.ViewButton" = "View"
    "Order.CancelButton" = "Cancel"
    "Product.PriceLabel" = "Price:"
    "Product.StockLabel" = "Stock:"
    "Product.DescriptionLabel" = "Description:"
    "Product.BackButton" = "Back to Products"
    "Product.FilterLabel" = "Filter by Category:"
    "Product.AllFilter" = "All"
    "Product.FruitsFilter" = "Fruits"
    "Product.VegetablesFilter" = "Vegetables"
    "Product.NoProducts" = "No products found."
    "Product.DetailsButton" = "Details"
    "newLayout.PopularItems" = "Popular Items"
    "newLayout.NewArrivals" = "New Arrivals"

}

$arabicValues = @{
    "FinalizeOrderError" = "فشل في إتمام الطلب."
    "FinalizeOrderSuccess" = "تم إتمام طلبك بنجاح!"
    "GetAll.Contains" = "يحتوي على"
    "GetAll.Delete" = "حذف"
    "GetAll.Details" = "التفاصيل"
    "GetAll.Edit" = "تعديل"
    "GetAll.Header" = "استكشف فئاتنا"
    "GetAll.NoCategories" = "لم يتم العثور على فئات."
    "GetAll.Products" = "منتجات"
    "GetAll.SubHeader" = "اكتشف مجموعة متنوعة من المنتجات منظمة حسب الفئة."
    "GetAll.Title" = "جميع الفئات"
    "GetAll.ViewProducts" = "عرض المنتجات"
    "LoginRequiredError" = "يجب تسجيل الدخول لتنفيذ هذا الإجراء."
    "newLayout.About" = "حول"
    "newLayout.AllProducts" = "جميع المنتجات"
    "newLayout.Categories" = "الفئات"
    "newLayout.Home" = "الرئيسية"
    "newLayout.Login" = "تسجيل الدخول"
    "newLayout.Logout" = "تسجيل الخروج"
    "newLayout.MyProfile" = "ملفي الشخصي"
    "newLayout.NavbarBrand" = "متجري"
    "newLayout.SearchButton" = "بحث"
    "newLayout.SearchPlaceholder" = "البحث عن المنتجات..."
    "newLayout.Shop" = "تسوق"
    "newLayout.SiteTitle" = "المتجر"
    "newLayout.ViewOrder" = "عرض الطلب"
    "NotFoundError" = "العنصر غير موجود."
    "Success" = "تمت إضافة المنتج إلى الطلب!"
    "SuccessMessage" = "تمت العملية بنجاح!"
    "ErrorMessage" = "حدث خطأ."
    "SignUp.Header" = "تسجيل الاشتراك"
    "SignUp.NameLabel" = "الاسم"
    "SignUp.EmailLabel" = "البريد الإلكتروني"
    "SignUp.PasswordLabel" = "كلمة المرور"
    "SignUp.PhoneLabel" = "رقم الهاتف"
    "SignUp.LocationLabel" = "الموقع"
    "SignUp.SubmitButton" = "إرسال"
    "Login.Header" = "تسجيل الدخول"
    "Login.EmailLabel" = "البريد الإلكتروني"
    "Login.PasswordLabel" = "كلمة المرور"
    "Login.RememberMe" = "تذكرني"
    "Category.Details.Title" = "تفاصيل الفئة"
    "Category.ProductsLabel" = "المنتجات:"
    "Category.NoProducts" = "لا يوجد منتجات في هذه الفئة."
    "Category.BackButton" = "العودة للقائمة"
    "Category.EditButton" = "تعديل"
    "Category.DeleteButton" = "حذف"
    "Category.ProductCount" = "يحتوي على"
    "Category.DetailsButton" = "التفاصيل"
    "Shop.Header.Title" = "تسوق بأناقة"
    "Shop.Header.Subtitle" = "تصفح منتجاتنا المذهلة"
    "Shop.SearchResults" = "عرض النتائج لـ:"
    "Shop.NoProducts.Title" = "لا يوجد منتجات متاحة حالياً."
    "Shop.NoProducts.Message" = "يرجى المراجعة لاحقاً!"
    "Shop.LowStock" = "المخزون منخفض"
    "Shop.OutOfStock" = "نفذ المخزون"
    "Shop.StockLabel" = "المخزون:"
    "Shop.AddToOrder" = "أضف إلى الطلب"
    "Shop.OutOfStockButton" = "نفذ المخزون"
    "Profile.Header" = "ملفي الشخصي"
    "Profile.UsernameLabel" = "اسم المستخدم"
    "Profile.EmailLabel" = "البريد الإلكتروني"
    "Profile.BackButton" = "العودة للرئيسية"
    "Profile.ViewOrdersButton" = "عرض الطلبات"
    "Profile.EditButton" = "تعديل الملف الشخصي"
    "Order.Current.Title" = "طلبي الحالي"
    "Order.NoActiveOrder" = "ليس لديك أي طلبات نشطة."
    "Order.TotalPriceLabel" = "السعر الإجمالي:"
    "Order.ItemCountLabel" = "عدد العناصر:"
    "Order.ProductColumn" = "المنتج"
    "Order.ImageColumn" = "الصورة"
    "Order.QuantityColumn" = "الكمية"
    "Order.UnitPriceColumn" = "سعر الوحدة"
    "Order.SubtotalColumn" = "المجموع الفرعي"
    "Order.BackButton" = "العودة"
    "Order.DeleteButton" = "حذف الطلب"
    "Order.DeleteConfirm" = "هل أنت متأكد من حذف هذا الطلب؟"
    "Order.EditButton" = "تعديل الطلب"
    "Order.CheckoutButton" = "الدفع"
    "Payment.Title" = "تصميم المادة لنظام البوتستراب"
    "Payment.CardNumberLabel" = "رقم البطاقة"
    "Payment.CardNumberPlaceholder" = "1234 5678 9012 3457"
    "Payment.CardholderLabel" = "اسم حامل البطاقة"
    "Payment.CardholderPlaceholder" = "اسم حامل البطاقة"
    "Payment.ExpirationLabel" = "تاريخ الانتهاء"
    "Payment.ExpirationPlaceholder" = "MM/YYYY"
    "Payment.CVVLabel" = "CVV"
    "Payment.CardNumberValidation" = "يرجى إدخال رقم بطاقة مكون من 16 رقمًا بتنسيق: 1234 5678 9012 3456"
    "Payment.CardholderValidation" = "الاسم يمكن أن يحتوي فقط على حروف ومسافات."
    "Payment.ExpirationValidation" = "يرجى إدخال تاريخ انتهاء صالح بتنسيق MM/YYYY."
    "Payment.CVVValidation" = "يجب أن يكون CVV مكونًا من 3 أرقام."
    "Payment.ChooseTitle" = "اختر طريقة الدفع الخاصة بك"
    "Payment.ChooseDescription" = "يرجى اختيار كيفية دفع طلبك."
    "Payment.CardButton" = "الدفع بالبطاقة"
    "Payment.CashButton" = "الدفع نقدًا"
    "Order.Edit.Title" = "تعديل طلبك"
    "Order.ApplyChangesButton" = "تطبيق التغييرات"
    "Order.RemoveColumn" = "إزالة"
    "Order.Finalized.Title" = "الطلبات المنتهية"
    "Order.TotalPriceColumn" = "السعر الإجمالي"
    "Order.ItemCountColumn" = "عدد العناصر"
    "Order.LocationColumn" = "موقع العميل"
    "Order.DeliveryNameColumn" = "اسم التوصيل"
    "Order.FinalizedOnColumn" = "تم الإنهاء في"
    "Order.PaymentMethodColumn" = "طريقة الدفع"
    "Order.ActionsColumn" = "الإجراءات"
    "Order.ViewButton" = "عرض"
    "Order.CancelButton" = "إلغاء"
    "Product.PriceLabel" = "السعر:"
    "Product.StockLabel" = "المخزون:"
    "Product.DescriptionLabel" = "الوصف:"
    "Product.BackButton" = "العودة للمنتجات"
    "Product.FilterLabel" = "تصفية حسب الفئة:"
    "Product.AllFilter" = "الكل"
    "Product.FruitsFilter" = "الفواكه"
    "Product.VegetablesFilter" = "الخضروات"
    "Product.NoProducts" = "لا يوجد منتجات."
    "Product.DetailsButton" = "التفاصيل"
    "newLayout.PopularItems" = "العناصر الشائعة"
    "newLayout.NewArrivals" = "الواردات الجديدة"
  
}


# English .resx
$xml = [xml]@"
<root>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
</root>
"@
foreach ($name in $names) {
    $data = $xml.CreateElement("data")
    $data.SetAttribute("name", $name)
    $value = $xml.CreateElement("value")
    $value.InnerText = $englishValues[$name]
    $data.AppendChild($value)
    $xml.DocumentElement.AppendChild($data)
}
$xml.Save($resxPath)

# Arabic .resx
$xml = [xml]@"
<root>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
</root>
"@
foreach ($name in $names) {
    $data = $xml.CreateElement("data")
    $data.SetAttribute("name", $name)
    $value = $xml.CreateElement("value")
    $value.InnerText = $arabicValues[$name]
    $data.AppendChild($value)
    $xml.DocumentElement.AppendChild($data)
}
$xml.Save($arabicResxPath)

Write-Host "Resource files generated successfully."