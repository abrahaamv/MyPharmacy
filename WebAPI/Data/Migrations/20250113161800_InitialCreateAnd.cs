using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ean = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Slug = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrls = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specifications = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DISFAVIL" },
                    { 2, "ZUUM" },
                    { 3, "ENSURE" },
                    { 4, "SUPERIOR" },
                    { 5, "ALKA-SELTZER" },
                    { 6, "ALKOH" },
                    { 7, "SAL ANDREWS" },
                    { 8, "HIDRAVIDA" },
                    { 9, "MK" },
                    { 10, "VESA" },
                    { 11, "PANADOL" },
                    { 12, "GENESIS" },
                    { 13, "CERAVE" },
                    { 14, "VITAFLENACO" },
                    { 15, "TUMS" },
                    { 16, "CASTILLA" },
                    { 17, "ALKA EXTREME" },
                    { 18, "HANSAPLAST" },
                    { 19, "PEDIASURE" },
                    { 20, "ATLEVIT" },
                    { 21, "TYLENOL" },
                    { 22, "EXCELLENT" },
                    { 23, "DEOPIES" },
                    { 24, "GLUCERNA" },
                    { 25, "ASPIRINA" },
                    { 26, "METAMUCIL" },
                    { 27, "EUCERIN" },
                    { 28, "SANTA FE NATURA" },
                    { 29, "TABCIN" },
                    { 30, "GATORADE" },
                    { 31, "DORIVAL" },
                    { 32, "AFFECTIVE" },
                    { 33, "ADVIL" },
                    { 34, "VIJOSA" },
                    { 35, "SIETE MARES" },
                    { 36, "VIROGRIP" },
                    { 37, "VICK" },
                    { 38, "VICK VAPORUB" },
                    { 39, "LA BONNE VIE" },
                    { 40, "ALKA AD" },
                    { 41, "DUREX" },
                    { 42, "DRIVE MEDICAL" },
                    { 43, "PRUDENCE" },
                    { 44, "SAVORÂ" },
                    { 45, "PASINERVA" },
                    { 46, "INFASA" },
                    { 47, "QUALIPHARM" },
                    { 48, "PEPTO BISMOL" },
                    { 49, "PEDEX" },
                    { 50, "GELA-KIN" },
                    { 51, "VITABIOTICS" },
                    { 52, "BENET" },
                    { 53, "ENTEREX" },
                    { 54, "MASCARA" },
                    { 55, "VIVE" },
                    { 56, "CUREBAND" },
                    { 57, "GOOD BRANDS" },
                    { 58, "MEDIMART" },
                    { 59, "OMRON" },
                    { 60, "BEPANTHENE" },
                    { 61, "MEDIHEALTH" },
                    { 62, "VITAL FUERTE" },
                    { 63, "JOHNSON & JOHNSON" },
                    { 64, "MEDIPRODUCTS" },
                    { 65, "CENTRUM" },
                    { 66, "NEXCARE" },
                    { 67, "LA ROCHE-POSAY" },
                    { 68, "CAPLIN POINT LABORAT" },
                    { 69, "FRYCIA" },
                    { 70, "ALEVE" },
                    { 71, "BEBERÂ" },
                    { 72, "PIEX" },
                    { 73, "AMBIDERM" },
                    { 74, "ROEMMERS" },
                    { 75, "GUTIS" },
                    { 76, "CANESTEN" },
                    { 77, "DONOVAN" },
                    { 78, "FARMANDINA" },
                    { 79, "ISDIN" },
                    { 80, "DEL PILAR" },
                    { 81, "NUTRAMEDIX" },
                    { 82, "ALCON" },
                    { 83, "UNESIA" },
                    { 84, "NEXT-TABS" },
                    { 85, "GRIIN" },
                    { 86, "CEBION" },
                    { 87, "NEUMONIL" },
                    { 88, "COFAL" },
                    { 89, "CHEMILCO" },
                    { 90, "K-Y GEL" },
                    { 91, "REDOXITOS" },
                    { 92, "ALKA  GASTRIC" },
                    { 93, "VISINA" },
                    { 94, "NIPRO" },
                    { 95, "BAYER" },
                    { 96, "REDOXON" },
                    { 97, "BALLENA AZUL" },
                    { 98, "FERRER" },
                    { 99, "SIN MARCA" },
                    { 100, "CARDIOASPIRINA" },
                    { 101, "GMS" },
                    { 102, "PROCTER & GAMBLE" },
                    { 103, "PEDIALYTE" },
                    { 104, "VICHY" },
                    { 105, "B&J" },
                    { 106, "EXELTIS" },
                    { 107, "SUKROL" },
                    { 108, "FARKOT" },
                    { 109, "ANCALMO" },
                    { 110, "MENARINI" },
                    { 111, "LEMON GRASS" },
                    { 112, "GLAXOSMITHKLINE" },
                    { 113, "RENU" },
                    { 114, "ABL PHARMA" },
                    { 115, "VITAMIN SHOPPE" },
                    { 116, "SCOTT" },
                    { 117, "GNC" },
                    { 118, "BABARIA" },
                    { 119, "ASOFARMA" },
                    { 120, "GHL INTERNACION" },
                    { 121, "CHINOIN" },
                    { 122, "NEUROFORTAN" },
                    { 123, "PINGUINO" },
                    { 124, "ISIS PHARMA" },
                    { 125, "SANTA FE" },
                    { 126, "LANCASCO" },
                    { 127, "JALOMA" },
                    { 128, "CARDIO VITAL" },
                    { 129, "BMA PHARMA" },
                    { 130, "ABBOTT CFR" },
                    { 131, "DOLOKALORUB" },
                    { 132, "HIMALAYA" },
                    { 133, "DIQUIVA" },
                    { 134, "LAINEZ" },
                    { 135, "RUSSELL STOVER" },
                    { 136, "BAYKID" },
                    { 137, "BIODERMA" },
                    { 138, "GASTRO-BISMOL" },
                    { 139, "CIRUELAX" },
                    { 140, "BABE" },
                    { 141, "CICATRICURE" },
                    { 142, "ACIERTO" },
                    { 143, "VIZCAINO" },
                    { 144, "PRUMISA" },
                    { 145, "NIKZON" },
                    { 146, "LEONFLAX" },
                    { 147, "SANOFI CHC" },
                    { 148, "BONIN" },
                    { 149, "MERCK" },
                    { 150, "GENERIX" },
                    { 151, "UNIPHARM" },
                    { 152, "DENK" },
                    { 153, "VERDE VITA" },
                    { 154, "GUASURE" },
                    { 155, "QUIFARMA" },
                    { 156, "PROCAPS" },
                    { 157, "PIERSAN" },
                    { 158, "ICN GROSMAN" },
                    { 159, "ZEPOL" },
                    { 160, "MED PHARMA" },
                    { 161, "SEBAPHARMA" },
                    { 162, "VITAGEL" },
                    { 163, "BUSSIE" },
                    { 164, "PROFOOT" },
                    { 165, "FUTURO" },
                    { 166, "FARMAMEDICA" },
                    { 167, "QUINFICA" },
                    { 168, "BAYER  HEALTHCARE P" },
                    { 169, "JANSSEN" },
                    { 170, "ACON" },
                    { 171, "COREGA" },
                    { 172, "BIOCLEAN" },
                    { 173, "VIFOR" },
                    { 174, "GLOBAL FARMA" },
                    { 175, "CHURCH&DWIGHT" },
                    { 176, "PROTEINOL" },
                    { 177, "ROCHE" },
                    { 178, "LAFAGE" },
                    { 179, "DAVIS LAB." },
                    { 180, "LEUKOPLAST" },
                    { 181, "BIO TRUE" },
                    { 182, "ROWA WAGNER" },
                    { 183, "BIOTA" },
                    { 184, "FERRIDOCE" },
                    { 185, "ASTRA ZENECA" },
                    { 186, "LAXMI PHARMAC." },
                    { 187, "BALIARDA" },
                    { 188, "ALFER" },
                    { 189, "ROWE" },
                    { 190, "ESCUDO" },
                    { 191, "TERAMED" },
                    { 192, "VOLTAREN NOVARTIS" },
                    { 193, "LUNDBECK" },
                    { 194, "NUTRISON" },
                    { 195, "PHARMALAT" },
                    { 196, "ORGANON" },
                    { 197, "PAILL" },
                    { 198, "BOEHRINGER INGELHEIM" },
                    { 199, "MERCK SHARP & D" },
                    { 200, "ACINO PHARMA" },
                    { 201, "BIO-OIL" },
                    { 202, "LANSIER" },
                    { 203, "VIU" },
                    { 204, "ABBOTT LAB." },
                    { 205, "GLAXO PHARMA" },
                    { 206, "OSHI" },
                    { 207, "ALDO UNION" },
                    { 208, "GEX" },
                    { 209, "MEFASA" },
                    { 210, "BENESSI" },
                    { 211, "SERVIER" },
                    { 212, "PFIZER" },
                    { 213, "EXELTIS NOVARTIS" },
                    { 214, "BIOGAIA" },
                    { 215, "PHARBEST" },
                    { 216, "HIDRATOMIC" },
                    { 217, "ACCU-ANSWER" },
                    { 218, "NOVARTIS-COHEN" },
                    { 219, "SAVAL" },
                    { 220, "CHOLSAMAJ" },
                    { 221, "GARDEN HOUSE" },
                    { 222, "IPROFASA" },
                    { 223, "MILAGRO DE LA SELVA" },
                    { 224, "BENESTAR" },
                    { 225, "GRUPO FARMA" },
                    { 226, "SESDERMA S.A" },
                    { 227, "HARRY POTTER" },
                    { 228, "CRAYOLA SILLY SCENTS" },
                    { 229, "BONLIFE" },
                    { 230, "BENADRYL" },
                    { 231, "CHALVER" },
                    { 232, "CHILE" },
                    { 233, "ODDENT" },
                    { 234, "QG5" },
                    { 235, "SOPHIA" },
                    { 236, "HEIDELG" },
                    { 237, "ROHAPHARMA" },
                    { 238, "MEDITEMP" },
                    { 239, "INTECFA" },
                    { 240, "HIDRISAGE" },
                    { 241, "ELI LILLY" },
                    { 242, "KRAL" },
                    { 243, "MEGALABS" },
                    { 244, "ROTTA" },
                    { 245, "TOP MODEL" },
                    { 246, "NOVARTIS PHARMA" },
                    { 247, "BAYER HEALTHCARE P" },
                    { 248, "OFTISOL" },
                    { 249, "PHARMAKON" },
                    { 250, "GRUNENTHAL" },
                    { 251, "QUIMIFAR" },
                    { 252, "SAFEGUARD" },
                    { 253, "EUROFARMA" },
                    { 254, "BIOCODEX" },
                    { 255, "ARSAL" },
                    { 256, "PANALAB" },
                    { 257, "PHISA" },
                    { 258, "LEVEN" },
                    { 259, "MICROLIFE" },
                    { 260, "ASPEN" },
                    { 261, "LUVECK" },
                    { 262, "NOVARTIS" },
                    { 263, "EISAI" },
                    { 264, "LABORATORIOS MIDI" },
                    { 265, "WELLCO" },
                    { 266, "SANAMIEL" },
                    { 267, "SILANES" },
                    { 268, "SANOFI" },
                    { 269, "MERZ" },
                    { 270, "CHEMINTER" },
                    { 271, "PRODES" },
                    { 272, "ALLERGAN" },
                    { 273, "BAGO" },
                    { 274, "JR PHARMA" },
                    { 275, "RUBIOS" },
                    { 276, "BEBES LLORONES" },
                    { 277, "SANOFI-ETICO" },
                    { 278, "SAN GERMAN" },
                    { 279, "PHILLIPS" },
                    { 280, "MEMBER'S MARK" },
                    { 281, "DOGMA" },
                    { 282, "CUMLAUDE LAB" },
                    { 283, "ROSCOE" },
                    { 284, "DRIVE DEVILBISS HEALTHCARE" },
                    { 285, "GRISI" },
                    { 286, "BOSTON" },
                    { 287, "EQUATE" },
                    { 288, "OM" },
                    { 289, "SANDOZ" },
                    { 290, "NIELSEN BAINBRIDGE" },
                    { 291, "FAES" },
                    { 292, "PROTEC" },
                    { 293, "ANGELINI" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sistema digestivo y Antiparasitarios" },
                    { 2, "OTC" },
                    { 3, "Dolor e inflamación" },
                    { 4, "Analgésicos" },
                    { 5, "Estomacales" },
                    { 6, "Respiratorios" },
                    { 7, "Dermatología" },
                    { 8, "Multivitamínicos, Suplementos & Sistema Óseo" },
                    { 9, "Cuidado Personal" },
                    { 10, "Antiviral, gripe y tos" },
                    { 11, "Vitaminas y Suplementos" },
                    { 12, "Bienestar Sexual" },
                    { 13, "Cuidado de los Pies" },
                    { 14, "Bienestar, equipo médico y soluciones hospitalarias" },
                    { 15, "Anticonceptivos, hormonal y salud sexual" },
                    { 16, "Asma, alergias y nasal" },
                    { 17, "Material de Curación" },
                    { 18, "Cardiovascular & Hipertensivo" },
                    { 19, "Antimicótico" },
                    { 20, "Sistema Nervioso" },
                    { 21, "Salud Bucal, Oftalmológico & Oído" },
                    { 22, "Oftálmicos y Óticos" },
                    { 23, "Diabetes" },
                    { 24, "Diabetes y tiroides" },
                    { 25, "Medicamentos de Alta Especialidad" },
                    { 26, "Embarazo & lactancia infantil" },
                    { 27, "Sistema Urinario" },
                    { 28, "Colesterol y Triglicérido" },
                    { 29, "Antibiótico" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Dolor" },
                    { 2, 5, "Sueros" },
                    { 3, 6, "Resfríos" },
                    { 4, 9, "Dermocosméticos" },
                    { 5, 11, "Preventivos" },
                    { 6, 12, "Condones" },
                    { 7, 13, "Talcos" },
                    { 8, 17, "Hisopos" },
                    { 9, 17, "Otros Materiales" },
                    { 10, 11, "Vitaminas" },
                    { 11, 6, "Congestión Nasal" },
                    { 12, 5, "Dolor y Malestar" },
                    { 13, 17, "Guantes y Cubrebocas" },
                    { 14, 5, "Antiácidos" },
                    { 15, 13, "Accesorios cuidado de pies" },
                    { 16, 11, "Suplementos Nutricionales" },
                    { 17, 22, "Gotas para los ojos" },
                    { 18, 23, "Equipos y Accesorios" },
                    { 19, 13, "Antimicóticos Pies" },
                    { 20, 4, "Musculares e Inflamación" },
                    { 21, 11, "Vitaminas y Suplementos/Calcio / Embarazo" },
                    { 22, 6, "Tos" },
                    { 23, 9, "Aceites y Cremas" },
                    { 24, 6, "Alergias" },
                    { 25, 22, "Oídos" },
                    { 26, 17, "Banditas y telas adhesivas" },
                    { 27, 17, "Gasas y Vendas" },
                    { 28, 5, "Antiparasitarios" },
                    { 29, 25, "Alta Especialidad" },
                    { 30, 9, "Para Cuidado Bucal" },
                    { 31, 12, "Anticonceptivos" },
                    { 32, 23, "Tratamiento Diabetes" },
                    { 33, 9, "Antiacné PX" },
                    { 34, 11, "Multivitamínicos" },
                    { 35, 5, "Antiulcerantes" },
                    { 36, 5, "Probióticos" },
                    { 37, 5, "Antidiarreicos" },
                    { 38, 12, "Suplementos" },
                    { 39, 5, "Laxante" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subcategories");
        }
    }
}
