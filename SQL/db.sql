--database: pgdemo;
--schema: public


------------------------------------------------------ create table ------------------------------------------------------
create table if not exists product
(
	id bigserial not null
		constraint product_pkey
			primary key,
	name varchar(100) not null,
	description varchar(500),
	price numeric not null,
	category json,
	categoryb jsonb
)
;

comment on table product is '产品'
;

comment on column product.name is '产品名称'
;

comment on column product.description is '产品描述'
;

comment on column product.price is '产品价格'
;

create table if not exists "order"
(
	id bigserial not null
		constraint order_pkey
			primary key,
	title varchar(100) not null,
	create_date timestamp not null,
	total_price numeric not null,
	total_amount integer not null
)
;

comment on table "order" is '订单'
;

comment on column "order".title is '标题'
;

comment on column "order".create_date is '下单日期'
;

comment on column "order".total_price is '总价格'
;

comment on column "order".total_amount is '总数量'
;

create table if not exists order_item
(
	id bigserial not null
		constraint order_item_pkey
			primary key,
	product_id bigint not null,
	order_id bigint not null,
	price numeric
)
;

comment on table order_item is '订单明细'
;

comment on column order_item.product_id is '货品ID'
;

comment on column order_item.order_id is '订单id'
;

comment on column order_item.price is '当前价格'
;

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