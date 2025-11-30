-- Archivo: cafe_shopping_test_data.sql

-- Insertar datos de prueba en la tabla CATEGORY
INSERT INTO CATEGORY (name, description, Status) VALUES
('Bebidas Calientes', 'Café, té, chocolate, y otras bebidas servidas calientes.', TRUE),
('Pastelería', 'Productos horneados como pasteles, galletas, y muffins.', TRUE),
('Bebidas Frías', 'Refrescos, jugos, y cafés helados.', TRUE);

-- Insertar datos de prueba en la tabla PROMOTION
INSERT INTO PROMOTION (name, amount, type, startDate, endDate, Status) VALUES
('Descuento de Invierno', 0.15, 'Porcentaje', '2025-12-01', '2026-02-28', TRUE),
('2x1 en Pasteles', 0.00, 'Oferta', '2025-11-10', '2025-11-30', TRUE),
('Envío Gratis', 5.00, 'Fijo', '2025-11-01', '2025-12-31', FALSE); -- Promoción inactiva

-- Insertar datos de prueba en la tabla PRODUCT (***CAMBIO: Se añade 'description'***)
INSERT INTO PRODUCT (ProductName, expirationDate, price, ID_category, ID_promotion, description, Status) VALUES
('Espresso Doble', NULL, 2.50, 1, 1, 'Dos shots intensos de café arábiga.', TRUE), 
('Muffin de Arándanos', '2025-12-05', 3.00, 2, 2, 'Muffin fresco con arándanos orgánicos.', TRUE),
('Latte Helado', NULL, 4.00, 3, NULL, 'Café latte con leche fría y hielo.', TRUE),
('Té Verde', NULL, 2.00, 1, NULL, 'Té verde orgánico sin azúcar.', TRUE);

-- Insertar datos de prueba en la tabla SUPPLIER
INSERT INTO SUPPLIER (name, address, phone, email, Status) VALUES
('Granos Selectos S.A.', 'Calle Falsa 123', '555-1234', 'ventas@granosselectos.com', TRUE),
('Distribuidora Láctea del Sur', 'Avenida Siempre Viva 45', '555-5678', 'contacto@lacteasur.com', TRUE),
('Panadería Artesanal', 'Boulevard de los Sueños 789', '555-9012', 'info@panartesanal.com', TRUE);

-- Insertar datos de prueba en la tabla CAFE
INSERT INTO CAFE (name, address, company, Status) VALUES
('Café Central Miraflores', 'Av. Larco 101', 'Café Corp', TRUE),
('Café Express San Isidro', 'Calle Los Robles 202', 'Café Corp', TRUE),
('Café Gourmet', 'Jirón de la Unión 303', 'Delicias Gourmet S.A.C.', TRUE);

-- Insertar datos de prueba en la tabla INVENTORY (asumiendo IDs de CAFE, PRODUCT y SUPPLIER)
INSERT INTO INVENTORY (ID_cafe, ID_product, quantity, ID_supplier, Status) VALUES
(1, 1, 100, 1, TRUE),
(1, 2, 50, 3, TRUE),
(2, 3, 75, 2, TRUE),
(3, 4, 120, 1, TRUE);

-- Insertar datos de prueba en la tabla USERS
INSERT INTO USERS (name, phoneNumber, email, password, Rrole, Status) VALUES
('Ana García', '987654321', 'ana.garcia@email.com', 'hashedpass123', 'Cliente', TRUE),
('Luis Pérez', '999888777', 'luis.perez@email.com', 'hashedpass456', 'Administrador', TRUE),
('María López', '965432100', 'maria.lopez@email.com', 'hashedpass789', 'Cliente', TRUE);

-- Insertar datos de prueba en la tabla SHOPPING (asumiendo IDs de USERS)
INSERT INTO SHOPPING (ID_user, date, total, Discount, Promotion, Status) VALUES
(1, '2025-11-05 10:30:00', 5.00, 0.50, 'Descuento de Invierno', TRUE),
(3, '2025-11-06 14:45:00', 6.00, 0.00, NULL, TRUE),
(1, '2025-11-07 18:00:00', 3.00, 0.00, '2x1 en Pasteles', TRUE);

-- Insertar datos de prueba en la tabla SHOPPING_DETAIL (asumiendo IDs de PRODUCT y SHOPPING)
INSERT INTO SHOPPING_DETAIL (ID_product, quantity, amount, ID_shopping, Status) VALUES
(1, 2, 5.00, 1, TRUE),
(3, 1, 4.00, 2, TRUE),
(2, 1, 3.00, 3, TRUE),
(4, 1, 2.00, 2, TRUE);

-- Insertar datos de prueba en la tabla PURCHASE_HISTORY (asumiendo IDs de USERS y SHOPPING)
INSERT INTO PURCHASE_HISTORY (IdUser, IdShopping, Id_payment, Status) VALUES
(1, 1, 'PAY-12345', TRUE),
(3, 2, 'PAY-67890', TRUE),
(1, 3, 'PAY-11223', TRUE);

-- ----------------------------------------------------------------------------------------------------
-- DATOS DE RESERVAS (NUEVOS)
-- ----------------------------------------------------------------------------------------------------

### 2. Inserción de Datos para `RESERVATION` y `RESERVATION_DETAIL`

```sql
-- Insertar datos de prueba en la tabla RESERVATION (asumiendo IDs de USERS y CAFE)
INSERT INTO RESERVATION (ID_user, ID_cafe, reservation_date, reservation_code, reservation_status, notes) VALUES
(1, 1, '2025-12-10', 'RES-A101', 'CONFIRMED', 'Reserva de mesa para cumpleaños.'), -- Ana reserva en Café Central
(3, 2, '2025-12-12', 'RES-B202', 'PENDING', 'Reserva para una reunión de negocios.'), -- María reserva en Café Express
(1, 3, '2025-12-01', 'RES-C303', 'CONFIRMED', NULL); -- Ana reserva en Café Gourmet

-- Insertar datos de prueba en la tabla RESERVATION_DETAIL (asumiendo IDs de RESERVATION y PRODUCT)
INSERT INTO RESERVATION_DETAIL (ID_reservation, ID_product, quantity, detail_description) VALUES
(1, 2, 5, 'Pre-orden de Muffins para la mesa.'), -- Reserva 1 pre-ordena 5 Muffins
(2, 3, 2, 'Latte Helado sin azúcar, para el inicio de la reunión.'), -- Reserva 2 pre-ordena 2 Latte Helado
(3, NULL, NULL, 'Mesa cerca de la ventana.'); -- Reserva 3 (solo mesa, sin pre-orden de producto)