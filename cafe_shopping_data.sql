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

-- Insertar datos de prueba en la tabla PRODUCT (asumiendo IDs de CATEGORY y PROMOTION)
INSERT INTO PRODUCT (ProductName, expirationDate, price, ID_category, ID_promotion, Status) VALUES
('Espresso Doble', NULL, 2.50, 1, 1, TRUE), -- ID_category=1 (Bebidas Calientes), ID_promotion=1 (Descuento de Invierno)
('Muffin de Arándanos', '2025-11-15', 3.00, 2, 2, TRUE), -- ID_category=2 (Pastelería), ID_promotion=2 (2x1 en Pasteles)
('Latte Helado', NULL, 4.00, 3, NULL, TRUE), -- ID_category=3 (Bebidas Frías), Sin promoción
('Té Verde', NULL, 2.00, 1, NULL, TRUE);

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
(1, 1, 100, 1, TRUE), -- Café Central tiene 100 Espresso Doble del Granos Selectos
(1, 2, 50, 3, TRUE), -- Café Central tiene 50 Muffin de Arándanos de Panadería Artesanal
(2, 3, 75, 2, TRUE), -- Café Express tiene 75 Latte Helado de Distribuidora Láctea
(3, 4, 120, 1, TRUE); -- Café Gourmet tiene 120 Té Verde de Granos Selectos

-- Insertar datos de prueba en la tabla USERS
INSERT INTO USERS (name, phoneNumber, email, password, Rrole, Status) VALUES
('Ana García', '987654321', 'ana.garcia@email.com', 'hashedpass123', 'Cliente', TRUE),
('Luis Pérez', '999888777', 'luis.perez@email.com', 'hashedpass456', 'Administrador', TRUE),
('María López', '965432100', 'maria.lopez@email.com', 'hashedpass789', 'Cliente', TRUE);

-- Insertar datos de prueba en la tabla SHOPPING (asumiendo IDs de USERS)
INSERT INTO SHOPPING (ID_user, date, total, Discount, Promotion, Status) VALUES
(1, '2025-11-05 10:30:00', 5.00, 0.50, 'Descuento de Invierno', TRUE), -- Ana García
(3, '2025-11-06 14:45:00', 6.00, 0.00, NULL, TRUE), -- María López
(1, '2025-11-07 18:00:00', 3.00, 0.00, '2x1 en Pasteles', TRUE); -- Ana García

-- Insertar datos de prueba en la tabla SHOPPING_DETAIL (asumiendo IDs de PRODUCT y SHOPPING)
INSERT INTO SHOPPING_DETAIL (ID_product, quantity, amount, ID_shopping, Status) VALUES
(1, 2, 5.00, 1, TRUE), -- 2 Espresso Doble para Shopping 1
(3, 1, 4.00, 2, TRUE), -- 1 Latte Helado para Shopping 2
(2, 1, 3.00, 3, TRUE), -- 1 Muffin de Arándanos para Shopping 3
(4, 1, 2.00, 2, TRUE); -- 1 Té Verde para Shopping 2

-- Insertar datos de prueba en la tabla PURCHASE_HISTORY (asumiendo IDs de USERS y SHOPPING)
INSERT INTO PURCHASE_HISTORY (IdUser, IdShopping, Id_payment, Status) VALUES
(1, 1, 'PAY-12345', TRUE),
(3, 2, 'PAY-67890', TRUE),
(1, 3, 'PAY-11223', TRUE);