--
-- File generated with SQLiteStudio v3.4.17 on ѕт сен 12 10:55:34 2025
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Data_sdelky
CREATE TABLE IF NOT EXISTS Data_sdelky (ID INTEGER PRIMARY KEY AUTOINCREMENT, quantity_data_sdelki STRING);

-- Table: Dom_magazina
CREATE TABLE IF NOT EXISTS Dom_magazina (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_Dom STRING);

-- Table: Gorod_magazina
CREATE TABLE IF NOT EXISTS Gorod_magazina (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_Goroda STRING);

-- Table: Info_Magazine
CREATE TABLE IF NOT EXISTS Info_Magazine (ID INTEGER PRIMARY KEY AUTOINCREMENT, nazvanie_magazinov STRING, dom_magazina STRING, gorod_magazina STRING, plochad_magazina INTEGER, ylicha_magazina STRING, kolichectvo_cotryndikov INTEGER, familya_direktora STRING, imya_direktora STRING, otchestvo_direktora STRING, prodovaemya_texnika STRING, primecanie STRING);

-- Table: info_o_D_N
CREATE TABLE IF NOT EXISTS info_o_D_N (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name STRING, Printer STRING, Tip TEXT, obem_xranimoi_pamyati STRING, tip_podclycheniya STRING, data_izgotovleniya STRING, garantiya INTEGER, prodovaemaya_texnika STRING, kolichestvo INTEGER, primechanie STRING);

-- Table: Info_o_K_P
CREATE TABLE IF NOT EXISTS Info_o_K_P (prodavech INTEGER PRIMARY KEY AUTOINCREMENT, tovar TEXT, pokypatel TEXT, kolichetvo_tovara INTEGER, chena_za_edinichy_tovara INTEGER, data_cdelki INTEGER);

-- Table: kol_vo_sotrudnikov
CREATE TABLE IF NOT EXISTS kol_vo_sotrudnikov (ID INTEGER PRIMARY KEY AUTOINCREMENT, quantity_kolichestvo_sotrudnikov STRING);

-- Table: Kol_vo_tovara
CREATE TABLE IF NOT EXISTS Kol_vo_tovara (ID INTEGER PRIMARY KEY AUTOINCREMENT, quantity_tovara STRING);

-- Table: Name_info_o_D_N
CREATE TABLE IF NOT EXISTS Name_info_o_D_N (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_nazvanie STRING);

-- Table: nazvanie_magazina
CREATE TABLE IF NOT EXISTS nazvanie_magazina (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_magazina STRING);

-- Table: Ploshad_magazina
CREATE TABLE IF NOT EXISTS Ploshad_magazina (ID INTEGER PRIMARY KEY AUTOINCREMENT, quantity_ploshad_magazina STRING);

-- Table: PRICE_ED_TOVARA
CREATE TABLE IF NOT EXISTS PRICE_ED_TOVARA (ID INTEGER PRIMARY KEY AUTOINCREMENT, quantity_chena_za_ed_tovara STRING);

-- Table: Seller
CREATE TABLE IF NOT EXISTS Seller (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_prodavech STRING);

-- Table: Tip
CREATE TABLE IF NOT EXISTS Tip (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_tip STRING);

-- Table: Tovar
CREATE TABLE IF NOT EXISTS Tovar (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_tovar STRING);

-- Table: watch_demo
CREATE TABLE IF NOT EXISTS watch_demo (ID INTEGER PRIMARY KEY AUTOINCREMENT);

-- Table: ylicha_magazina
CREATE TABLE IF NOT EXISTS ylicha_magazina (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name_ylicha_magazina STRING);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
