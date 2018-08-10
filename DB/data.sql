------------------------------------------------------ insert data ------------------------------------------------------
-- insert [product] data
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (2, '苹果', '新鲜水果', 12.7, null, null);
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (3, '香蕉', '新鲜水果', 34.2, null, null);
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (4, '榴莲', '@p0', 134, '{"First":"水果","Second":"进口水果","Complex":[{"First":"水果"},{"Second":"进口水果"}]}', '{"First": "水果", "Second": "进口水果", "Complex": [{"First": "水果"}, {"Second": "进口水果"}]}');
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (5, '香蕉', '@p0', 22, '{"First":"水果","Second":"进口水果","Complex":[{"First":"水果"},{"Second":"进口水果"}]}', '{"First": "水果", "Second": "进口水果", "Complex": [{"First": "水果"}, {"Second": "进口水果"}]}');
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (6, '香蕉', '@p0', 33, '{"First":"水果","Second":"进口水果"}', '{"First": "水果", "Second": "进口水果"}');
INSERT INTO public.product (id, name, description, price, category, categoryb) VALUES (8, '香蕉', '@p0', 44, '{"First":"水果","Second":"进口水果","Complex":[{"First":"水果"},{"Second":"进口水果"}]}', '{"First": "水果", "Second": "进口水果", "Complex": [{"First": "水果"}, {"Second": "进口水果"}]}');

-- insert [order] data
INSERT INTO public."order" (id, title, create_date, total_price, total_amount) VALUES (1, '订单1', '2018-08-02 00:00:00.000000', 0, 1);
INSERT INTO public."order" (id, title, create_date, total_price, total_amount) VALUES (11, '订单水果', '2018-08-03 10:06:59.568194', 46.9, 2);

-- insert [order_item] data
INSERT INTO public.order_item (id, product_id, order_id, price) VALUES (1, 2, 1, 12.7);
INSERT INTO public.order_item (id, product_id, order_id, price) VALUES (15, 2, 11, 12.7);
INSERT INTO public.order_item (id, product_id, order_id, price) VALUES (16, 3, 11, 34.2);