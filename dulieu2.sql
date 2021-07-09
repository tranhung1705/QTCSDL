Create database CUAHANG_TAPHOA
use CUAHANG_TAPHOA
create table HOA_DON_NHAP(MaHDN int not null, NgayNhap date not null,
GioNhap time not null,MaCC int not null, Tongtien int,
constraint PK_HOA_DON_NHAP Primary key(MaHDN, MaCC))
create table HDNHAP_CHI_TIET(MaHDN int not null, MaH int not null,
SoLuongNhap int not null, Thanhtien int,
constraint PK_HDNHAP_CHI_TIET Primary key(MaHDN, MaH))
insert into HOADON_NHAP
values ('1','2021-12-12','12:22:20.6000000','123456789','0'),
       ('2','2021-11-12','19:12:20.5000000','123456783','0'),
	   ('3','2020-10-12','15:72:20.6000000','123456785','0'),
	   ('4','2020-09-08','01:62:20.6000000','123456782','0'),
	   ('5','2022-03-12','14:19:20.7000000','123456781','0'),
	   ('6','2019-05-22','17:15:20.4000000','123456786','0'),
	   ('7','2021-12-17','10:13:20.6000000','123456780','0'),
	   ('5','2021-07-12','09:52:20.6000000','123456788','0'),
	   ('9','2021-02-10','23:11:20.8000000','123456787','0'),
	   ('10','2021-01-12','11:12:20.1000000','123456784','0')

select * from HOADON_NHAP
select * from CUNG_CAP


insert into HDNHAP_CHI_TIET
values ('1','508','20','2000000'),
       ('2','503','2','2000000'),
	   ('3','501','10','2000000'),
	   ('4','505','5','2500000'),
	   ('5','502','1','400000'),
	   ('6','509','6','500000'),
	   ('7','510','2','2200000'),
	   ('8','507','10','2000000'),
	   ('9','506','5','5000000'),
	   ('10','504','20','200000')

select * from HDNHAP_CHI_TIET
select * from HANG
select * from CUNG_CAP

Update HANG
Set SoLuongTon = SoLuongTon + SoLuongNhap
From HDNHAP_CHI_TIET inner join HANG
On HDNHAP_CHI_TIET.MaH=HANG.MaH
select * from HANG


select * from HOADON_NHAP
select * from HOADON_NHAP join HDNHAP_CHI_TIET on HOADON_NHAP.MaHDN = HDNHAP_CHI_TIET.MaHDN





