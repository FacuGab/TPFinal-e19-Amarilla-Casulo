--post creación bd
DROP TABLE MARCAS
ALTER TABLE ARTICULOS
DROP COLUMN CODIGO;

--- #### AGREGADO DE DATOS ####
--insert usuarios
INSERT INTO USUARIOS(Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen) VALUES ('Admin', 'Perez', 16240658, 'mail@mail.com', '1', 'calle falsa 123', 'A', 'no tiene img1');
INSERT INTO USUARIOS(Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen) VALUES ('Manu', 'cas', 47240658, 'email@mail.com', '1', 'calle falsa 1234', 'C', 'no tiene img2');
INSERT INTO USUARIOS(Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen) VALUES ('Facu', 'azul', 89240658, 'email1@mail.com', '1', 'calle falsa 12345', 'E', 'no tiene img3');
INSERT INTO USUARIOS(Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen) VALUES ('Lucho', 'apu', 56245658, 'email2@mail.com', '1', 'calle falsa 12356', 'E', 'no tiene img4');
select * from USUARIOS

--insert pedidos
INSERT INTO PEDIDOS VALUES(2, 5,10, '2023-06-22', 'OK', 'luis 123', 0, 15000);
INSERT INTO PEDIDOS VALUES(3, 15,10, '2023-06-02', 'OK', 'luis 123', 0, 30000);

--insert categorias
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('1', 'Monitores', 'https://cdn-icons-png.flaticon.com/256/81/81793.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('2', 'Placa de video', 'https://w7.pngwing.com/pngs/388/581/png-transparent-graphics-cards-video-adapters-computer-icons-computer-hardware-electronics-handheld-devices-computer-electronics-text-rectangle-thumbnail.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('3', 'Disco Solido', 'https://cdn-icons-png.flaticon.com/256/4400/4400889.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('4', 'Disco rígido', 'https://e7.pngegg.com/pngimages/605/607/png-clipart-logo-brand-data-font-hard-disc-icon-text-rectangle-thumbnail.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('5', 'Memoria Ram', 'https://cdn-icons-png.flaticon.com/256/882/882566.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('6', 'Teclado', 'https://cdn-icons-png.flaticon.com/256/5740/5740915.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('7', 'Mouse', 'https://i.pinimg.com/originals/e9/09/ea/e909ea4f8dff04c13c36d9856a977ebd.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('8', 'Auriculares', 'https://cdn-icons-png.flaticon.com/256/260/260315.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('9', 'Placa madre', 'https://cdn-icons-png.flaticon.com/256/2004/2004686.png');
INSERT INTO CATEGORIAS (id, descripcion, urlImagen) VALUES ('10', 'Procesador', 'https://cdn-icons-png.flaticon.com/256/1086/1086611.png');

select * from categorias;

--Insert marcas
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('1', 'Asus', 'https://images.freeimages.com/fic/images/icons/2796/metro_uinvert_dock/256/asus.png');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('2', 'MSI', 'https://pbs.twimg.com/profile_images/674660612547432448/-mac6Il7_400x400.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('3', 'Amd', 'https://compragamer.net/imagenes_marcas/imagen_marca_320_9_411.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('4', 'Intel', 'https://compragamer.net/imagenes_marcas/imagen_marca_364_9_203.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('5', 'Logitech', 'https://static.macupdate.com/products/62352/l/logitech-g-hub-logo.webp?v=1671137096');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('6', 'Redragon', 'https://styles.redditmedia.com/t5_42nhxk/styles/communityIcon_vb8305k77xo61.png?width=256&s=7a4a763b7f929dd1ee7fe6ea04f9a27d71c581e0');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('7', 'HyperX', 'https://compragamer.net/imagenes_marcas/imagen_marca_365_9_441.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('8', 'Genius', 'https://www.lacasadelacomputadora.com.uy/imgs/representaciones/foto31_71.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('9', 'Western Digital', 'https://compragamer.net/imagenes_marcas/imagen_marca_322_9_619.jpg');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('10', 'ViewSonic', 'https://e7.pngegg.com/pngimages/466/107/png-clipart-hewlett-packard-viewsonic-computer-monitors-logo-computer-software-hewlett-packard-text-logo.png');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('11', 'Asrock', 'https://cdn.shopify.com/s/files/1/0331/2789/1082/products/ASRock_grande.jpg?v=1582152086');
INSERT INTO MARCAS (id, descripcion, urlImagen) VALUES ('12', 'Adata', 'https://2.bp.blogspot.com/-yTiEnencHOA/T08JEEqNlKI/AAAAAAAABts/luVxNynFvW8/s1600/a6.jpg');
	
		
select * from MARCAS;

--insert imagenes
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('5','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33359_Monitor_Gamer_Viewsonic_24__VX2468-PC-MHD_Curvo_165hz_46d27d6d-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('5','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33360_Monitor_Gamer_Viewsonic_24__VX2468-PC-MHD_Curvo_165hz_a6deb2ae-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('5','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33362_Monitor_Gamer_Viewsonic_24__VX2468-PC-MHD_Curvo_165hz_ac523dc3-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('6','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_23821_Monitor_Gamer_Viewsonic_27__VX2768_Curvo_2K_144Hz_1ms_FreeSync_HDMI_DP_af5acee2-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('6','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_23823_Monitor_Gamer_Viewsonic_27__VX2768_Curvo_2K_144Hz_1ms_FreeSync_HDMI_DP_428c53c0-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('2','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20991_Monitor_Gamer_MSI_24__Optix_G241_144Hz_IPS_1ms_204c32c9-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('2','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20992_Monitor_Gamer_MSI_24__Optix_G241_144Hz_IPS_1ms_4be4b651-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('2','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20993_Monitor_Gamer_MSI_24__Optix_G241_144Hz_IPS_1ms_3a4c4094-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('1','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27036_Monitor_ASUS_21.5__VP228HE-J_Full_HD_1ms_HDMI_VGA_29ad25c0-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('1','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27037_Monitor_ASUS_21.5__VP228HE-J_Full_HD_1ms_HDMI_VGA_313cf0e0-med.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('1','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27036_Monitor_ASUS_21.5__VP228HE-J_Full_HD_1ms_HDMI_VGA_29ad25c0-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('3','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33878_Monitor_ASUS_24__VA24EHE-J_Full_HD_ac877e59-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('3','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33879_Monitor_ASUS_24__VA24EHE-J_Full_HD_e5e827ed-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('3','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33881_Monitor_ASUS_24__VA24EHE-J_Full_HD_699389e6-med.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('4','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33822_Monitor_ASUS_27__Full_HD_HDMI_VGA_VA27EHE-J_8b229ce8-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('4','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33823_Monitor_ASUS_27__Full_HD_HDMI_VGA_VA27EHE-J_45efe665-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('4','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33824_Monitor_ASUS_27__Full_HD_HDMI_VGA_VA27EHE-J_e7f15015-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('7','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36639_Placa_de_Video_MSI_GeForce_RTX_3090_24GB_GDDR6X_VENTUS_3X_OC_58618d16-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('7','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21085_Placa_de_Video_MSI_GeForce_RTX_3090_24GB_GDDR6X_VENTUS_3X_OC_8ab3b437-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('7','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21087_Placa_de_Video_MSI_GeForce_RTX_3090_24GB_GDDR6X_VENTUS_3X_OC_4842e14d-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('8','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36550_Placa_de_Video_ASUS_Phoenix_GeForce_GTX_1630_4GB_GDDR6_b0a0edd2-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('8','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36551_Placa_de_Video_ASUS_Phoenix_GeForce_GTX_1630_4GB_GDDR6_0aa6ea72-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('9','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35211_Placa_de_Video_ASUS_GeForce_GTX_1660_SUPER_6GB_GDDR6_OC_TUF_91e6cd72-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('9','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_17243_Placa_de_Video_ASUS_GeForce_GTX_1660_SUPER_6GB_GDDR6_OC_TUF_9b71c1cd-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('9','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_17244_Placa_de_Video_ASUS_GeForce_GTX_1660_SUPER_6GB_GDDR6_OC_TUF_04cc5a64-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('10','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27548_Placa_de_Video_ASUS_GeForce_GTX_1650_4GB_GDDR6_TUF_GAMING_71e82ff4-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('10','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16562_Placa_de_Video_ASUS_GeForce_GTX_1650_4GB_GDDR6_TUF_GAMING_25c172c8-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('11','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19289_Placa_de_Video_Asrock_Radeon_RX_550_2GB_GDDR5_Phantom_Gaming_99528ce8-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('11','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19290_Placa_de_Video_Asrock_Radeon_RX_550_2GB_GDDR5_Phantom_Gaming_1e8baa4a-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('12','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29154_Placa_de_Video_Asrock_Radeon_RX_6800_XT_16GB_GDDR6_Phantom_Gaming_D_OC_b76349fe-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('12','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29155_Placa_de_Video_Asrock_Radeon_RX_6800_XT_16GB_GDDR6_Phantom_Gaming_D_OC_f28765e9-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('12','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29157_Placa_de_Video_Asrock_Radeon_RX_6800_XT_16GB_GDDR6_Phantom_Gaming_D_OC_b3f0fc37-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('13','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_32107_Disco_Solido_SSD_M.2_WD_500GB_Blue_SN570_3500MB_s_NVMe_PCI-E_Gen3_x4_TLC_3135e1e9-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('13','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_32108_Disco_Solido_SSD_M.2_WD_500GB_Blue_SN570_3500MB_s_NVMe_PCI-E_Gen3_x4_TLC_9a9da7d5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('14','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28600_Disco_Solido_SSD_M.2_WD_500GB_Black_SN750_SE_3600MB_s_PCI-E_X4_NVMe_GEN4_b815bec0-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('14','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28602_Disco_Solido_SSD_M.2_WD_500GB_Black_SN750_SE_3600MB_s_PCI-E_X4_NVMe_GEN4_654966d5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('15','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33159_Disco_Solido_SSD_M.2_WD_500GB_WD_Black_SN770_5000MB_s_NVMe_PCI-E_x4_Gen_4_7a4a307b-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('15','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33160_Disco_Solido_SSD_M.2_WD_500GB_WD_Black_SN770_5000MB_s_NVMe_PCI-E_x4_Gen_4_2aff08dd-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('16','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35589_Disco_Solido_SSD_M.2_WD_1TB_WD_Black_SN770_5150MB_s_NVMe_PCI-E_x4_Gen_4_7a4a307b-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('16','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33622_Disco_Solido_SSD_M.2_WD_1TB_WD_Black_SN770_5150MB_s_NVMe_PCI-E_x4_Gen_4_60cef2e6-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('17','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29777_Disco_Solido_SSD_Adata_240GB_SU650SS_520MB_s__8b455937-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('17','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29778_Disco_Solido_SSD_Adata_240GB_SU650SS_520MB_s__c1c34d0c-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('18','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_9018_Disco_R__gido_WD_1TB_BLUE_64MB_SATA_6.0GB_s__ca74d162-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('18','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_1196_Disco_R__gido_WD_1TB_BLUE_64MB_SATA_6.0GB_s__1545a4f9-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('19','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21014_Disco_Rigido_WD_2TB_BLUE_256MB_SATA_6.0GB_s_44f766ac-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('20','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21015_Disco_Rigido_WD_2TB_BLUE_256MB_SATA_6.0GB_s_d1e138ed-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('21','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35996_Disco_Rigido_WD_2TB_BLUE_256MB_SATA_6.0GB_s_7200RPM_dc36f8f5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('22','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_26480_Disco_Rigido_WD_12TB_Red_Pro_7.2K_RPM_256MB_c66a3fa3-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('23','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_26484_Disco_Rigido_WD_12TB_Gold_7.2K_RPM_256MB_856fe552-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('24','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_13221_Memoria_Adata_DDR4_4GB_2666MHz_Value__aa6df289-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('25','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16184_Memoria_Adata_DDR4_8GB_2666MHz_Value_Sodimm_Notebook_38c2e2af-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('26','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_18814_Memoria_Adata_DDR4_8GB_3200MHz_Premier_c6036c27-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('27','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25890_Memoria_Adata_DDR4_16GB_3200MHz_CL16_XPG_GAMMIX_D20_Black_6b1582d3-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('28','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28924_Memoria_Adata_DDR4_8GB_3200MHz_XPG_Spectrix_D60G_RGB_Titanium_88f51e0f-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('29','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28926_Memoria_Adata_DDR4_8GB_3200MHz_XPG_Spectrix_D50_RGB_Titanium_446ebe28-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('30','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29885_Memoria_Adata_DDR4__2x8GB__16GB_5000MHz_XPG_Spectrix_D50_Xtreme_RGB_CL19_18133a6d-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('31','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33275_Teclado_Mecanico_Logitech_PRO_TKL_LOL_2_Switch_Brown_30e10b48-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('32','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19865_Teclado_Mecanico_Logitech_G513_Carbon_RGB_Switch_GX_Brown_Espa__ol_9ccf7c47-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('33','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33269_Teclado_Mecanico_Logitech_POP_Blast_Yellow_Wireless_725996a0-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('34','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36665_Teclado_Mecanico_Logitech_POP_Coral_Rose_Wireless_065ab138-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('35','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16207_Teclado_Logitech_G815_Mechanical_RGB_Lightsync_5ab9b8b1-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('36','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19373_Teclado_Mecanico_Logitech_G915_TKL_RGB_Lightspeed_Inalambrico_065f0cec-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('38','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28612_Mouse_Redragon_Centrophorus_M601_RGB_e00743a5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('38','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28614_Mouse_Redragon_Centrophorus_M601_RGB_9e2363c4-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('39','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_8760_Mouse_Redragon_Mirage_M690_2.5GHz_Wireless_1739dc55-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('39','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_8759_Mouse_Redragon_Mirage_M690_2.5GHz_Wireless_13e59d69-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('40','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20297_Mouse_Redragon_Storm_Elite_M988_RGB_Black_f25e5643-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('40','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20299_Mouse_Redragon_Storm_Elite_M988_RGB_Black_da0b8b96-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('41','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_18989_Mouse_Logitech_M110S_Negro_Blue_USB_9ecef8f4-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('41','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_18992_Mouse_Logitech_M110S_Negro_Blue_USB_f0eff56d-med.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('42','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24397_Mouse_Logitech_M110S_Red_520ace37-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('42','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24400_Mouse_Logitech_M110S_Red_572df13e-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('43','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21243_Mouse_Logitech_G305_Lightspeed_Wireless_Blue_9c250057-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('43','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21245_Mouse_Logitech_G305_Lightspeed_Wireless_Blue_44244ac2-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('43','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21248_Mouse_Logitech_G305_Lightspeed_Wireless_Blue_d27a8d95-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('44','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36399_Auriculares_Redragon_Zeus_X_H510-RGB_7.1_Surround__a5046a9f-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('44','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36400_Auriculares_Redragon_Zeus_X_H510-RGB_7.1_Surround__a6d2f307-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('45','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29699_Auriculares_Redragon_Icon_H520_PC_PS4_42412af1-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('45','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29700_Auriculares_Redragon_Icon_H520_PC_PS4_99b94941-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('46','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_9612_Auriculares_HP_HyperX_Cloud_Stinger_Gaming_Negro__PC___PS4___Switch___XBOX_27f1808e-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('46','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_9613_Auriculares_HP_HyperX_Cloud_Stinger_Gaming_Negro__PC___PS4___Switch___XBOX_c8b462ee-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('47','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35919_Auriculares_HP_HyperX_Cloud_Black_Blue_PS4_PS5_bdb54c92-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('47','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35920_Auriculares_HP_HyperX_Cloud_Black_Blue_PS4_PS5_e80b9f85-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('48','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_31171_Auriculares_Genius_GX_Gaming_HS-G710V_91b68c27-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('48','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_31170_Auriculares_Genius_GX_Gaming_HS-G710V_e7832ba5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('49','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27936_Auriculares_Logitech_G335_White_32282a6d-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('49','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27937_Auriculares_Logitech_G335_White_5d46d2e5-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('50','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21848_Mother_MSI_A520M-A_PRO_AM4_29d05f8c-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('50','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21849_Mother_MSI_A520M-A_PRO_AM4_8baafa01-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('51','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20551_Mother_ASUS_PRIME_A520M-K_AM4_f5d89e00-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('51','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20553_Mother_ASUS_PRIME_A520M-K_AM4_9216f824-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('52','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25784_Mother_MSI_B450_Gaming_Plus_Max_AM4_5dd0dc29-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('52','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25785_Mother_MSI_B450_Gaming_Plus_Max_AM4_d5692b77-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('53','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_15692_Mother_MSI_X570-A_PRO_AM4_bbf981bd-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('53','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_15693_Mother_MSI_X570-A_PRO_AM4_b29443fe-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('54','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_30440_Mother_ASUS_PRIME_H610M-E_D4_S1700_3402c168-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('54','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_30441_Mother_ASUS_PRIME_H610M-E_D4_S1700_b1b07b46-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('55','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_34006_Mother_Asrock_H610M-HVS_LGA_1700_486791bd-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('55','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_34007_Mother_Asrock_H610M-HVS_LGA_1700_7eedfce1-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('56','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24392_Mother_Asrock_A520M-HDV_AM4_5c7ae4d7-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('56','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24393_Mother_Asrock_A520M-HDV_AM4_affcd72d-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('57','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16749_Procesador_AMD_RYZEN_5_3600_4.2GHz_Turbo_AM4_Wraith_Stealth_Cooler_f8ab4915-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('57','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_14074_Procesador_AMD_RYZEN_5_3600_4.2GHz_Turbo_AM4_Wraith_Stealth_Cooler_14f3a44e-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('58','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_31696_Procesador_AMD_Ryzen_5_5500_4.2GHz_Turbo___Wraith_Stealth_Cooler_ca9fc7de-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('59','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_22302_Procesador_AMD_Ryzen_9_5950X_4.9GHz_Turbo_AM4_-_No_incluye_Cooler_9d34d3b3-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('60','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_13151_Procesador_Intel_Pentium_G4560_3.5GHz_Socket_1151_Kaby_Lake_OEM_Sin_Cooler_58161f82-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('61','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19228_Procesador_Intel_Core_i7_10700_4.8GHz_Turbo_Socket_1200_Comet_Lake_e3d7d847-grn.jpg');
INSERT INTO IMAGENES (idArticulo,  urlImagen) VALUES ('62','https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25668_Procesador_Intel_Core_i5_11600KF_4.9GHz_Turbo_Socket_1200_Rocket_Lake_7f61810f-grn.jpg');

select * from IMAGENES

--insert Articulos
INSERT INTO ARTICULOS VALUES ('1','Monitor ASUS 21.5"', 'VP228HE-J Full HD 1ms HDMI VGA', '1', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27034_Monitor_ASUS_21.5__VP228HE-J_Full_HD_1ms_HDMI_VGA_a797ab9e-grn.jpg', '58650', '1', '10');
INSERT INTO ARTICULOS VALUES ('2','Monitor Gamer MSI 24"', 'Optix G241 144Hz IPS 1ms', '2', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20990_Monitor_Gamer_MSI_24__Optix_G241_144Hz_IPS_1ms_18f8b03a-grn.jpg', '119750', '1', '10');
INSERT INTO ARTICULOS VALUES ('3','Monitor ASUS 24"', 'VA24EHE-J Full HD', '1', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33878_Monitor_ASUS_24__VA24EHE-J_Full_HD_ac877e59-grn.jpg', '77900', '1', '10');
INSERT INTO ARTICULOS VALUES ('4','Monitor ASUS 27"', ' Full HD HDMI VGA VA27EHE-J', '1', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33822_Monitor_ASUS_27__Full_HD_HDMI_VGA_VA27EHE-J_8b229ce8-grn.jpg', '60000', '1', '10');
INSERT INTO ARTICULOS VALUES ('5','Monitor Gamer Viewsonic 24"', ' VX2468-PC-MHD Curvo 165hz', '11', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33359_Monitor_Gamer_Viewsonic_24__VX2468-PC-MHD_Curvo_165hz_46d27d6d-grn.jpg', '111500', '1', '10');
INSERT INTO ARTICULOS VALUES ('6','Monitor Gamer Viewsonic 27"', 'VX2768 Curvo 2K 144Hz 1ms FreeSync HDMI DP', '11', '1', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_23822_Monitor_Gamer_Viewsonic_27__VX2768_Curvo_2K_144Hz_1ms_FreeSync_HDMI_DP_071c1138-grn.jpg', '207300', '1', '10');
INSERT INTO ARTICULOS VALUES ('7','Placa de Video MSI GeForce RTX 3090', '24GB GDDR6X VENTUS 3X OC', '2', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36639_Placa_de_Video_MSI_GeForce_RTX_3090_24GB_GDDR6X_VENTUS_3X_OC_58618d16-grn.jpg', '443650', '1', '10');
INSERT INTO ARTICULOS VALUES ('8','Placa de Video ASUS Phoenix GeForce GTX 1630', '4GB GDDR6', '1', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36550_Placa_de_Video_ASUS_Phoenix_GeForce_GTX_1630_4GB_GDDR6_b0a0edd2-grn.jpg', '130000', '1', '10');
INSERT INTO ARTICULOS VALUES ('9','Placa de Video ASUS GeForce GTX 1660 SUPER', '6GB GDDR6 OC TUF', '1', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35211_Placa_de_Video_ASUS_GeForce_GTX_1660_SUPER_6GB_GDDR6_OC_TUF_91e6cd72-grn.jpg', '205000', '1', '10');
INSERT INTO ARTICULOS VALUES ('10','Placa de Video ASUS GeForce GTX 1650', '4GB GDDR6 TUF GAMING', '1', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27548_Placa_de_Video_ASUS_GeForce_GTX_1650_4GB_GDDR6_TUF_GAMING_71e82ff4-grn.jpg', '190000', '1', '10');
INSERT INTO ARTICULOS VALUES ('11','Placa de Video Asrock Radeon RX 550', '2GB GDDR5 Phantom Gaming', '11', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19289_Placa_de_Video_Asrock_Radeon_RX_550_2GB_GDDR5_Phantom_Gaming_99528ce8-grn.jpg', '58000', '1', '10');
INSERT INTO ARTICULOS VALUES ('12','Placa de Video Asrock Radeon RX 6800', 'XT 16GB GDDR6 Phantom Gaming D OC', '11', '2', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29154_Placa_de_Video_Asrock_Radeon_RX_6800_XT_16GB_GDDR6_Phantom_Gaming_D_OC_b76349fe-grn.jpg', '283000', '1', '10');
INSERT INTO ARTICULOS VALUES ('13','Disco Solido SSD M.2 WD 500GB Blue', 'SN570 3500MB/s NVMe PCI-E Gen3 x4 TLC', '9', '3', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_32107_Disco_Solido_SSD_M.2_WD_500GB_Blue_SN570_3500MB_s_NVMe_PCI-E_Gen3_x4_TLC_3135e1e9-grn.jpg', '27000', '1', '10');
INSERT INTO ARTICULOS VALUES ('14','Disco Solido SSD M.2 WD 500GB Black', 'SN750 SE 3600MB/s PCI-E X4 NVMe GEN4', '9', '3', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28600_Disco_Solido_SSD_M.2_WD_500GB_Black_SN750_SE_3600MB_s_PCI-E_X4_NVMe_GEN4_b815bec0-grn.jpg', '31000', '1', '10');
INSERT INTO ARTICULOS VALUES ('15','Disco Solido SSD M.2 WD 500GB WD_Black', 'SN770 5000MB/s NVMe PCI-E x4 Gen 4', '9', '3', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33159_Disco_Solido_SSD_M.2_WD_500GB_WD_Black_SN770_5000MB_s_NVMe_PCI-E_x4_Gen_4_7a4a307b-grn.jpg', '42300', '1', '10');
INSERT INTO ARTICULOS VALUES ('16','Disco Solido SSD M.2 WD 1TB WD_Black SN770', '5150MB/s NVMe PCI-E x4 Gen 4', '9', '3', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35589_Disco_Solido_SSD_M.2_WD_1TB_WD_Black_SN770_5150MB_s_NVMe_PCI-E_x4_Gen_4_7a4a307b-grn.jpg', '69000', '1', '10');
INSERT INTO ARTICULOS VALUES ('17','Disco Solido SSD Adata 240GB', 'SU650SS 520MB/s*', '12', '3', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29777_Disco_Solido_SSD_Adata_240GB_SU650SS_520MB_s__8b455937-grn.jpg', '14000', '1', '10');
INSERT INTO ARTICULOS VALUES ('18','Disco Rígido WD 1TB BLUE', '64MB SATA 6.0GB/s ', '9', '4', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_9018_Disco_R__gido_WD_1TB_BLUE_64MB_SATA_6.0GB_s__ca74d162-grn.jpg', '22000', '1', '10');
INSERT INTO ARTICULOS VALUES ('19','Disco Rigido WD 2TB BLUE', '256MB SATA 6.0GB/s', '9', '4', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21014_Disco_Rigido_WD_2TB_BLUE_256MB_SATA_6.0GB_s_44f766ac-grn.jpg', '34000', '1', '10');
INSERT INTO ARTICULOS VALUES ('20','Disco Rigido WD 2TB BLUE', '256MB SATA 6.0GB/s 7200RPM', '9', '4', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35996_Disco_Rigido_WD_2TB_BLUE_256MB_SATA_6.0GB_s_7200RPM_dc36f8f5-grn.jpg', '34000', '1', '10');
INSERT INTO ARTICULOS VALUES ('21','Disco Rigido WD 12TB Red', 'Pro 7.2K RPM 256MB', '9', '4', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_26480_Disco_Rigido_WD_12TB_Red_Pro_7.2K_RPM_256MB_c66a3fa3-grn.jpg', '126000', '1', '10');
INSERT INTO ARTICULOS VALUES ('22','Disco Rigido WD 12TB Gold', '7.2K RPM 256MB', '9', '4', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_26484_Disco_Rigido_WD_12TB_Gold_7.2K_RPM_256MB_856fe552-grn.jpg', '128000', '1', '10');
INSERT INTO ARTICULOS VALUES ('23','Memoria Adata DDR4 4GB', ' 2666MHz Value ', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_13221_Memoria_Adata_DDR4_4GB_2666MHz_Value__aa6df289-grn.jpg', '10500', '1', '10');
INSERT INTO ARTICULOS VALUES ('24','Memoria Adata DDR4 8GB ', ' 2666MHz Value Sodimm Notebook', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16184_Memoria_Adata_DDR4_8GB_2666MHz_Value_Sodimm_Notebook_38c2e2af-grn.jpg', '17000', '1', '10');
INSERT INTO ARTICULOS VALUES ('25','Memoria Adata DDR4 8GB', '3200MHz Premier', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_18814_Memoria_Adata_DDR4_8GB_3200MHz_Premier_c6036c27-grn.jpg', '19500', '1', '10');
INSERT INTO ARTICULOS VALUES ('26','Memoria Adata DDR4 16GB', '3200MHz CL16 XPG GAMMIX D20 Black', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25890_Memoria_Adata_DDR4_16GB_3200MHz_CL16_XPG_GAMMIX_D20_Black_6b1582d3-grn.jpg', '43000', '1', '10');
INSERT INTO ARTICULOS VALUES ('27','Memoria Adata DDR4 8GB ', '3200MHz XPG Spectrix D60G RGB Titanium', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28924_Memoria_Adata_DDR4_8GB_3200MHz_XPG_Spectrix_D60G_RGB_Titanium_88f51e0f-grn.jpg', '21200', '1', '10');
INSERT INTO ARTICULOS VALUES ('28','Memoria Adata DDR4 8GB', '3200MHz XPG Spectrix D50 RGB Titanium', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28926_Memoria_Adata_DDR4_8GB_3200MHz_XPG_Spectrix_D50_RGB_Titanium_446ebe28-grn.jpg', '25000', '1', '10');
INSERT INTO ARTICULOS VALUES ('29','Memoria Adata DDR4 (2x8GB) 16GB ', '5000MHz XPG Spectrix D50 Xtreme RGB CL19', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29885_Memoria_Adata_DDR4__2x8GB__16GB_5000MHz_XPG_Spectrix_D50_Xtreme_RGB_CL19_18133a6d-grn.jpg', '340000', '1', '10');
INSERT INTO ARTICULOS VALUES ('30','Memoria Adata DDR4 8GB', '3600Mhz XPG Spectrix D45G RGB', '12', '5', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29565_Memoria_Adata_DDR4_8GB_3600Mhz_XPG_Spectrix_D45G_RGB_cbbc726d-grn.jpg', '24500', '1', '10');
INSERT INTO ARTICULOS VALUES ('31','Teclado Mecanico Logitech PRO TKL', 'LOL 2 Switch Brown', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33275_Teclado_Mecanico_Logitech_PRO_TKL_LOL_2_Switch_Brown_30e10b48-grn.jpg', '39000', '1', '10');
INSERT INTO ARTICULOS VALUES ('32','Teclado Mecanico Logitech G513', 'Carbon RGB Switch GX Brown Español', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19865_Teclado_Mecanico_Logitech_G513_Carbon_RGB_Switch_GX_Brown_Espa__ol_9ccf7c47-grn.jpg', '50000', '1', '10');
INSERT INTO ARTICULOS VALUES ('33','Teclado Mecanico Logitech POP Blast', 'Yellow Wireless', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_33269_Teclado_Mecanico_Logitech_POP_Blast_Yellow_Wireless_725996a0-grn.jpg', '52200', '1', '10');
INSERT INTO ARTICULOS VALUES ('34','Teclado Mecanico Logitech POP', 'Coral Rose Wireless', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36665_Teclado_Mecanico_Logitech_POP_Coral_Rose_Wireless_065ab138-grn.jpg', '52000', '1', '10');
INSERT INTO ARTICULOS VALUES ('35','Teclado Logitech G815', 'Mechanical RGB Lightsync', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16207_Teclado_Logitech_G815_Mechanical_RGB_Lightsync_5ab9b8b1-grn.jpg', '88000', '1', '10');
INSERT INTO ARTICULOS VALUES ('36','Teclado Mecanico Logitech G915 TKL', 'RGB Lightspeed Inalambrico', '5', '6', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19373_Teclado_Mecanico_Logitech_G915_TKL_RGB_Lightspeed_Inalambrico_065f0cec-grn.jpg', '115000', '1', '10');
INSERT INTO ARTICULOS VALUES ('37','Teclado Mecanico Logitech Aurora G715', 'Wireless White RGB', '5', '6', '', '119000', '1', '10');
INSERT INTO ARTICULOS VALUES ('38','Mouse Redragon Centrophorus ', 'M601 RGB', '6', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_28612_Mouse_Redragon_Centrophorus_M601_RGB_e00743a5-grn.jpg', '7300', '1', '10');
INSERT INTO ARTICULOS VALUES ('39','Mouse Redragon Mirage M690', '2.5GHz Wireless', '6', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_8760_Mouse_Redragon_Mirage_M690_2.5GHz_Wireless_1739dc55-grn.jpg', '7500', '1', '10');
INSERT INTO ARTICULOS VALUES ('40','Mouse Redragon Storm Elite M988', 'RGB Black', '6', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20297_Mouse_Redragon_Storm_Elite_M988_RGB_Black_f25e5643-grn.jpg', '13240', '1', '10');
INSERT INTO ARTICULOS VALUES ('41','Mouse Logitech M110S', 'Negro Blue USB', '5', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_18989_Mouse_Logitech_M110S_Negro_Blue_USB_9ecef8f4-grn.jpg', '3000', '1', '10');
INSERT INTO ARTICULOS VALUES ('42','Mouse Logitech M110S', 'Red Blue USB', '5', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24397_Mouse_Logitech_M110S_Red_520ace37-grn.jpg', '3000', '1', '10');
INSERT INTO ARTICULOS VALUES ('43','Mouse Logitech G305', 'Lightspeed Wireless Blue', '5', '7', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21243_Mouse_Logitech_G305_Lightspeed_Wireless_Blue_9c250057-grn.jpg', '18600', '1', '10');
INSERT INTO ARTICULOS VALUES ('44','Auriculares Redragon Zeus', 'RGB 7.1 Surround*', '6', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_36399_Auriculares_Redragon_Zeus_X_H510-RGB_7.1_Surround__a5046a9f-grn.jpg', '32000', '1', '10');
INSERT INTO ARTICULOS VALUES ('45','Auriculares Redragon Icon H520', 'PC PS4', '6', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_29699_Auriculares_Redragon_Icon_H520_PC_PS4_42412af1-grn.jpg', '30000', '1', '10');
INSERT INTO ARTICULOS VALUES ('46','Auriculares HP HyperX Cloud Stinger Gaming', 'Negro  PC | PS4 | Switch | XBOX', '7', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_9612_Auriculares_HP_HyperX_Cloud_Stinger_Gaming_Negro__PC___PS4___Switch___XBOX_27f1808e-grn.jpg', '24200', '1', '10');
INSERT INTO ARTICULOS VALUES ('47','Auriculares HP HyperX Cloud', 'Black Blue PS4 PS5', '7', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_35919_Auriculares_HP_HyperX_Cloud_Black_Blue_PS4_PS5_bdb54c92-grn.jpg', '32000', '1', '10');
INSERT INTO ARTICULOS VALUES ('48','Auriculares Genius GX', ' Gaming HS-G710V', '8', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_31170_Auriculares_Genius_GX_Gaming_HS-G710V_e7832ba5-grn.jpg', '11000', '1', '10');
INSERT INTO ARTICULOS VALUES ('49','Auriculares Logitech G335', 'White', '5', '8', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_27936_Auriculares_Logitech_G335_White_32282a6d-grn.jpg', '22000', '1', '10');
INSERT INTO ARTICULOS VALUES ('50','Mother MSI A520M-A PRO AM4', '', '2', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_21848_Mother_MSI_A520M-A_PRO_AM4_29d05f8c-grn.jpg', '55000', '1', '10');
INSERT INTO ARTICULOS VALUES ('51','Mother ASUS PRIME A520M-K AM4', '', '1', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_20551_Mother_ASUS_PRIME_A520M-K_AM4_f5d89e00-grn.jpg', '57750', '1', '10');
INSERT INTO ARTICULOS VALUES ('52','Mother MSI B450 Gaming Plus Max AM4', '', '2', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25784_Mother_MSI_B450_Gaming_Plus_Max_AM4_5dd0dc29-grn.jpg', '71000', '1', '10');
INSERT INTO ARTICULOS VALUES ('53','Mother MSI X570-A PRO AM4', '', '2', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_15692_Mother_MSI_X570-A_PRO_AM4_bbf981bd-grn.jpg', '98000', '1', '10');
INSERT INTO ARTICULOS VALUES ('54','Mother ASUS PRIME H610M-E D4 S1700', '', '1', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_30440_Mother_ASUS_PRIME_H610M-E_D4_S1700_3402c168-grn.jpg', '53500', '1', '10');
INSERT INTO ARTICULOS VALUES ('55','Mother Asrock H610M-HVS LGA 1700', '', '11', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_34006_Mother_Asrock_H610M-HVS_LGA_1700_486791bd-grn.jpg', '53000', '1', '10');
INSERT INTO ARTICULOS VALUES ('56','Mother Asrock A520M-HDV AM4', '', '11', '9', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_24392_Mother_Asrock_A520M-HDV_AM4_5c7ae4d7-grn.jpg', '52000', '1', '10');
INSERT INTO ARTICULOS VALUES ('57','Procesador AMD RYZEN 5 3600', '4.2GHz Turbo AM4 Wraith Stealth Cooler', '3', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_16749_Procesador_AMD_RYZEN_5_3600_4.2GHz_Turbo_AM4_Wraith_Stealth_Cooler_f8ab4915-grn.jpg', '94000', '1', '10');
INSERT INTO ARTICULOS VALUES ('58','Procesador AMD Ryzen 5 5500', '4.2GHz Turbo + Wraith Stealth Cooler', '3', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_31696_Procesador_AMD_Ryzen_5_5500_4.2GHz_Turbo___Wraith_Stealth_Cooler_ca9fc7de-grn.jpg', '100000', '1', '10');
INSERT INTO ARTICULOS VALUES ('59','Procesador AMD Ryzen 9 5950X', '4.9GHz Turbo AM4 - No incluye Cooler', '3', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_22302_Procesador_AMD_Ryzen_9_5950X_4.9GHz_Turbo_AM4_-_No_incluye_Cooler_9d34d3b3-grn.jpg', '250000', '1', '10');
INSERT INTO ARTICULOS VALUES ('60','Procesador Intel Pentium G4560', '3.5GHz Socket 1151 Kaby Lake OEM Sin Cooler', '4', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_13151_Procesador_Intel_Pentium_G4560_3.5GHz_Socket_1151_Kaby_Lake_OEM_Sin_Cooler_58161f82-grn.jpg', '19000', '1', '10');
INSERT INTO ARTICULOS VALUES ('61','Procesador Intel Core i7 10700', '4.8GHz Turbo Socket 1200 Comet Lake', '4', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_19228_Procesador_Intel_Core_i7_10700_4.8GHz_Turbo_Socket_1200_Comet_Lake_e3d7d847-grn.jpg', '191500', '1', '10');
INSERT INTO ARTICULOS VALUES ('62','Procesador Intel Core i5 11600KF', '4.9GHz Turbo Socket 1200 Rocket Lake', '4', '10', 'https://compragamer.net/pga/imagenes_publicadas/compragamer_Imganen_general_25668_Procesador_Intel_Core_i5_11600KF_4.9GHz_Turbo_Socket_1200_Rocket_Lake_7f61810f-grn.jpg', '140000', '1', '10');

select * from ARTICULOS