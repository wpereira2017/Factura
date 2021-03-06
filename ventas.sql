USE [Ventas]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 16/11/2020 10:40:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Costo] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Existencia] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 16/11/2020 10:40:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](300) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Creado] [datetime] NOT NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 16/11/2020 10:40:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([id], [Codigo], [Descripcion], [Precio], [Costo], [Activo], [Existencia]) VALUES (1, N'001', N'Borrador de Leche', CAST(10.50 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), 1, 10)
INSERT [dbo].[Articulo] ([id], [Codigo], [Descripcion], [Precio], [Costo], [Activo], [Existencia]) VALUES (2, N'002', N'Cuaderno Rayado', CAST(20.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), 1, 20)
INSERT [dbo].[Articulo] ([id], [Codigo], [Descripcion], [Precio], [Costo], [Activo], [Existencia]) VALUES (3, N'003', N'Libreta Rayada', CAST(28.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Articulo] ([id], [Codigo], [Descripcion], [Precio], [Costo], [Activo], [Existencia]) VALUES (4, N'004', N'Tajador con tapadera', CAST(3.50 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 1, 15)
INSERT [dbo].[Articulo] ([id], [Codigo], [Descripcion], [Precio], [Costo], [Activo], [Existencia]) VALUES (6, N'005', N'Caja de lápices de color de 12 unidades', CAST(32.00 AS Decimal(18, 2)), CAST(28.00 AS Decimal(18, 2)), 1, 100)
SET IDENTITY_INSERT [dbo].[Articulo] OFF
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([id], [Cliente], [Total], [Creado]) VALUES (1, N'fulanito', CAST(10.50 AS Decimal(18, 2)), CAST(N'2020-11-13T19:49:35.857' AS DateTime))
INSERT [dbo].[Factura] ([id], [Cliente], [Total], [Creado]) VALUES (2, N'Wendollin', CAST(11.55 AS Decimal(18, 2)), CAST(N'2020-11-14T15:56:08.960' AS DateTime))
INSERT [dbo].[Factura] ([id], [Cliente], [Total], [Creado]) VALUES (3, N'Wendollin', CAST(33.55 AS Decimal(18, 2)), CAST(N'2020-11-14T18:21:56.777' AS DateTime))
INSERT [dbo].[Factura] ([id], [Cliente], [Total], [Creado]) VALUES (4, N'Wendollin', CAST(11.55 AS Decimal(18, 2)), CAST(N'2020-11-15T12:25:46.423' AS DateTime))
SET IDENTITY_INSERT [dbo].[Factura] OFF
SET IDENTITY_INSERT [dbo].[FacturaDetalle] ON 

INSERT [dbo].[FacturaDetalle] ([id], [FacturaId], [ArticuloId], [Cantidad], [PrecioUnitario], [Monto]) VALUES (1, 1, 1, 1, CAST(10.50 AS Decimal(18, 2)), CAST(10.50 AS Decimal(18, 2)))
INSERT [dbo].[FacturaDetalle] ([id], [FacturaId], [ArticuloId], [Cantidad], [PrecioUnitario], [Monto]) VALUES (2, 2, 1, 1, CAST(10.50 AS Decimal(18, 2)), CAST(10.50 AS Decimal(18, 2)))
INSERT [dbo].[FacturaDetalle] ([id], [FacturaId], [ArticuloId], [Cantidad], [PrecioUnitario], [Monto]) VALUES (3, 3, 1, 1, CAST(10.50 AS Decimal(18, 2)), CAST(10.50 AS Decimal(18, 2)))
INSERT [dbo].[FacturaDetalle] ([id], [FacturaId], [ArticuloId], [Cantidad], [PrecioUnitario], [Monto]) VALUES (4, 3, 2, 1, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[FacturaDetalle] ([id], [FacturaId], [ArticuloId], [Cantidad], [PrecioUnitario], [Monto]) VALUES (5, 4, 1, 1, CAST(10.50 AS Decimal(18, 2)), CAST(10.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[FacturaDetalle] OFF
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Articulo]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Factura1] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([id])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Factura1]
GO
