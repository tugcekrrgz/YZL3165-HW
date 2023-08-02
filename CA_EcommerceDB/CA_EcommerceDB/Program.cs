using CA_EcommerceDB.Models;
using CA_EcommerceDB.Repositories;

ECommerceDbContext db = new ECommerceDbContext();

CategoryRepository categoryRepository = new CategoryRepository();
CustomerRepository customerRepository = new CustomerRepository();
OrderRepository orderRepository = new OrderRepository();
ProductRepository productRepository = new ProductRepository();
StoreRepository storeRepository = new StoreRepository();
SupplierRepository supplierRepository = new SupplierRepository();


string[] menuListesi = { "1. Listele.","2. Ekle.","3. Güncelle.","4. Sil." };
string[] altMenuListesi = { "1. Kategori","2. Müşteri","3. Sipariş","4. Ürün","5. Mağaza","6. Tedarikçi" };
int secim = 0;
int secim2 = 0;
int id = 0;

void MenuYazdir()
{
    foreach (string menu in menuListesi)
        Console.WriteLine(menu);
    Console.Write("Lütfen bir seçim yapınız : ");
}
void AltMenuYazdir()
{
    foreach (string menu in altMenuListesi)
        Console.WriteLine(menu);
    Console.Write("Lütfen bir seçim yapınız : ");
}
void KategoriEkle()
{
    Category category = new Category();
    Console.Write("Kategori Adı Giriniz : ");
    category.CategoryName = Console.ReadLine();
    Console.WriteLine(categoryRepository.AddCategory(category));
}
void MusteriEkle()
{
    Customer customer = new Customer();
    Console.Write("Müşteri Adı Giriniz : ");
    customer.CustomerFirstName = Console.ReadLine();
    Console.Write("Müşteri Soyadı Giriniz : ");
    customer.CustomerLastName = Console.ReadLine();
    Console.Write("Müşteri Telefon Numarası Giriniz : ");
    customer.CustomerPhoneNumber = Console.ReadLine();
    Console.Write("Müşteri Mail Adresi Giriniz : ");
    customer.CustomerEmailAddress = Console.ReadLine();
    Console.WriteLine(customerRepository.AddCustomer(customer));

}
void KategoriGuncelle()
{
    Category category = new Category();
    category.CategoryId = id;
    Console.Write("Kategori Adı Giriniz : ");
    category.CategoryName = Console.ReadLine();
    Console.WriteLine(categoryRepository.UpdateCategory(category));
}
void MusteriGuncelle()
{
    Customer customer = new Customer();
    customer.CustomerId = id;
    Console.Write("Müşteri Adı Giriniz : ");
    customer.CustomerFirstName = Console.ReadLine();
    Console.Write("Müşteri Soyadı Giriniz : ");
    customer.CustomerLastName = Console.ReadLine();
    Console.Write("Müşteri Telefon Numarası Giriniz : ");
    customer.CustomerPhoneNumber = Console.ReadLine();
    Console.Write("Müşteri Mail Adresi Giriniz : ");
    customer.CustomerEmailAddress = Console.ReadLine();
    Console.WriteLine(customerRepository.UpdateCustomer(customer));

}
void KategoriSil()
{
    Console.WriteLine(categoryRepository.DeleteCategory(id));

}
void MusteriSil()
{
    Console.WriteLine(customerRepository.DeleteCustomer(id));
}

/*
while (true)
{
    MenuYazdir();
    try
    {
        secim=int.Parse(Console.ReadLine());
        if (secim < 0 || secim > menuListesi.Length)
            Console.WriteLine($"\nUYARI : 1 ile {menuListesi.Length} arasında bir seçim yapınız!\n");
        else
        {
            AltMenuYazdir();
            secim2 = int.Parse(Console.ReadLine());
            if (secim2 < 0 || secim2 > altMenuListesi.Length)
                Console.WriteLine($"\nUYARI : 1 ile {altMenuListesi.Length} arasında bir seçim yapınız!\n");
            else
            {
                switch (secim)
                {
                    case 1:
                        switch (secim2)
                        {
                            case 1:
                                Console.WriteLine("\n**** Kategori Listesi ****\n");
                                foreach (Category category in categoryRepository.GetCategories())
                                    Console.WriteLine(category.CategoryName);
                                break;
                            case 2:
                                Console.WriteLine("\n**** Müşteri Listesi ****\n");
                                foreach (Customer customer in customerRepository.GetCustomers())
                                    Console.WriteLine($"Müşteri Ad-Soyad: {customer.CustomerFirstName} {customer.CustomerLastName}" +
                                        $"\nMüşteri Adres: {customer.CustomerAddress}\n" +
                                        $"Müşteri Telefon Numarası: {customer.CustomerPhoneNumber}\n\n");
                                break;
                            case 3:
                                Console.WriteLine("\n**** Sipariş Listesi ****\n");
                                foreach (Order order in orderRepository.GetOrders())
                                    Console.WriteLine($"Sipariş Numarası: {order.OrderNumber}\n" +
                                        $"Sipariş Oluşturulma Tarihi: {order.OrderCreationDate}\n" +
                                        $"Sipariş Teslim Tarihi: {order.OrderDeliveryDate}\n" +
                                        $"Sipariş Ödeme Tipi: {order.Payment}\n" +
                                        $"Sipariş Oluşturan Müşteri: {order.Customer} {order.Customer}\n\n");
                                break;
                            case 4:
                                Console.WriteLine("\n**** Ürün Listesi ****\n");
                                foreach (Product product in productRepository.GetProducts())
                                    Console.WriteLine($"Ürün Adı: {product.ProductName}\n" +
                                        $"Ürün Fiyatı: {product.ProductPrice}\n" +
                                        $"Ürün Boyutu: {product.ProductSize}\n" +
                                        $"Ürün Rengi: {product.ProductColor}\n\n");
                                break;
                            case 5:
                                Console.WriteLine("\n**** Mağaza Listesi ****\n");
                                foreach (Store store in storeRepository.GetStores())
                                    Console.WriteLine($"Mağaza Adı: {store.StoreName}\nMağaza Adresi: {store.StoreAddress}\n" +
                                        $"Mağaza Telefon Numarası: {store.StorePhoneNumber}\n\n");
                                break;
                            case 6:
                                Console.WriteLine("\n**** Tedarikçi Listesi ****\n");
                                foreach (Supplier supplier in supplierRepository.GetSuppliers())
                                    Console.WriteLine($"Tedarikçi Adı: {supplier.SupplierName}\nTedarikçi Adresi: {supplier.SupplierAddress}\n" +
                                        $"Tedarikçi Telefon Numarası: {supplier.SupplierPhoneNumber}\n\n");
                                break;
                        }
                        break;
                    case 2:
                        switch (secim2)
                        {
                            case 1:
                                KategoriEkle();
                                break;
                            case 2:
                                MusteriEkle();
                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:

                                break;
                        }
                        break;
                    case 3:
                        Console.Write("Güncellenecek olan ID'yi giriniz : ");
                        id=int.Parse(Console.ReadLine());
                        switch (secim2)
                        {
                            case 1:
                                KategoriGuncelle();
                                break;
                            case 2:
                                MusteriGuncelle();
                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:

                                break;
                        }
                        break;
                    case 4:
                        switch (secim2)
                        {
                            case 1:
                                KategoriSil();
                                break;
                            case 2:
                                MusteriSil();
                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:

                                break;
                        }
                        break;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
*/


//SORGULAR
/*
//1-  Kadıköy'deki tedarikçileri listeleyin.
List<Supplier> suppliers = db.Suppliers.ToList();

Console.WriteLine("Linq to sql\n");
//Linq to sql
var result = from s in db.Suppliers
             where s.SupplierAddress == "Kadıköy"
             select new
             {
                 s.SupplierName,
                 s.SupplierAddress,
                 s.SupplierPhoneNumber
             };
foreach (var item in result.ToList())
{
    Console.WriteLine(item);
}
Console.WriteLine("\n");

Console.WriteLine("Linq to entity\n");
var result2 = db.Suppliers.Where(s => s.SupplierAddress == "Kadıköy").Select(x => new
{
    x.SupplierName,
    x.SupplierAddress,
    x.SupplierPhoneNumber
});
foreach (var item in result2.ToList())
{
    Console.WriteLine(item);
}
Console.WriteLine("\n");
*/
/*
//2- Kategorisi teknoloji olan ürünlerin fiyatlarını büyükten küçüğe sırala.
List<Product> products = db.Products.ToList();
int categoryId = db.Categories.Where(c => c.CategoryName == "Teknoloji").FirstOrDefault().CategoryId;

var result3 = db.Products.Where(p => p.CategoryId == categoryId).Select(x => new
{
    x.ProductName,
    x.ProductPrice,
    x.CategoryId
});

result3 = result3.OrderByDescending(x => x.ProductPrice);
foreach (var item in result3.ToList())
{
    Console.WriteLine(item);
}
Console.WriteLine("\n");
*/

/*
//3- Kategorisi giyim olan ürün adı pantolon, fiyatı 450, tedarikçisi Defacto,
//size 40, renk asker yeşili olan ürünü ekleyin.  

Product product = new Product();
int categoryId = db.Categories.Where(c => c.CategoryName == "Giyim").FirstOrDefault().CategoryId;
int supplierId = db.Suppliers.Where(s=> s.SupplierName=="Defacto").FirstOrDefault().SupplierId;
product.ProductName = "Pantolon";
product.ProductPrice = 450;
product.ProductSize = "40";
product.ProductColor = "Asker Yeşili";
product.CategoryId=categoryId;
product.SupplierId=supplierId;
product.ProductDefinition = $"{product.ProductColor} Bir {product.ProductName}";
db.Products.Add(product);

int saved=db.SaveChanges();
if (saved > 0)
    Console.WriteLine("Ürün Kaydedildi.");
else
    Console.WriteLine("Bir sorun oluştu!");
*/