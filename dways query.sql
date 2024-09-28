SET IDENTITY_INSERT Catergories ON
SET IDENTITY_INSERT Catergories off
SET IDENTITY_INSERT Products ON
SET IDENTITY_INSERT Products off
SET IDENTITY_INSERT Blogs ON
SET IDENTITY_INSERT Blogs off
INSERT INTO Catergories (CatergoryId, Name, Slug)
VALUES 
    ('1', 'Thực phẩm chức năng', 'tpcn'),
    ('2', 'Mỹ Phẩm', 'mp'),
    ('3', 'Công Nghệ', 'cn');

-- Chèn dữ liệu vào bảng sản phẩm (ví dụ bảng Products)
INSERT INTO Products (ProductId, ProductName, ProductDescription, ProductPhoto, ProductPrice, CatergoryId)
VALUES 
    ('1', 'HLSpan', 'Thực phẩm bổ sung sức khoẻ', 'HLSpan.jpg', 4850000, 1),
    ('2', 'Seawise', 'Thực phẩm bổ sung sức khoẻ', 'SeaWise.jpg', 3168000, 1),
    ('3', 'Immunogenix', 'Thực phẩm bổ sung sức khoẻ', 'Immunogenix.jpg', 3168000, 1),
    ('4', 'HStasis', 'Thực phẩm bổ sung sức khoẻ', 'Hstasis.jpg', 3168000, 1),
    ('5', 'CNRG', 'Thực phẩm bổ sung sức khoẻ', 'CNRG.jpg', 800000, 1),
    ('6', 'BGLO', 'Thực phẩm bổ sung sức khoẻ', 'BGLO.jpg', 4850000, 1),
    ('7', 'Phyto Cleaner', 'Thực phẩm bổ sung sức khoẻ', 'Cleanser.jpg', 1250000, 1),
    ('8', 'Phyto Serum', 'Thực phẩm bổ sung sức khoẻ', 'Peptide-serum.jpg', 4850000, 1),
    ('9', 'Day Cream', 'Thực phẩm bổ sung sức khoẻ', 'Day-cream.jpg', 4850000, 1),
    ('10', 'Phyto Toner', 'Thực phẩm bổ sung sức khoẻ', 'Toner.jpg', 4850000, 1);

INSERT INTO Blogs (BlogId, BlogName, BlogPhoto,BlogWriter,BlogDescriptions,BlogArticle,BlogDate)
VALUES 
    ('1', 'Bảo vệ sức khoẻ bản thân vói HLSpan', 'HLSpan.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('2', 'Để có thể có 1 cơ thể khoẻ mạnh hãy sử dụng Seawise', 'SeaWise.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('3', 'Tăng cường sức khoẻ xương khớp với Immunogenix','Immunogenix.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('4', 'Chỉ với HStasis đã có đủ vitamin và khoáng chất trong vòng 1 ngày', 'Hstasis.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('5', 'Cảm thấy khoẻ mạnh tức thì với CNRG','CNRG.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('6', 'Làm đẹp cùng với bộ sản phẩm BGLO','BGLO.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('7', 'Làm sạch da với Phyto Cleaner', 'Cleanser.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('8', 'Tăng cường chắc khoẻ da với Phyto Serum','Peptide-serum.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('9', 'Kem chống nắng Day Cream bảo vệ làn da của bạn','Day-cream.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31'),
    ('10', 'Tăng cường độ ẩm cho da với Phyto Toner', 'Toner.jpg','Long Duong','Chào mừng bạn đến với Dways - giải pháp toàn diện cho sức khoẻ của bạn! 
	Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','Trong kỷ nguyên công nghệ số hiện nay, sức khoẻ là thứ cần thiết. Dways ra đời với sứ mệnh biến hàng triệu người việt nam đều khoẻ mạnh.','2024-07-31');
	go
ALTER TABLE Blogs
ALTER COLUMN BlogDescriptions NVARCHAR(4000);