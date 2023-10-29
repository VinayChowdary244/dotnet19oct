use pubs
select * from authors

--projection
select au_fname, phone from authors
select au_fname 'Author Name' ,phone 'Contact Number' from authors
select au_fname as 'Author Name' ,phone as 'Contact Number' from authors
select au_fname Author_Name ,phone Contact_Number from authors
select * from authors where contract=0;

select title 'Book Name', price 'Cost', royalty 'Royalty Paid',
advance 'Advance received'
from titles 
where royalty  >10 and price>15
select * from ;
select title from titles where price >= 10 and price <=25
select title from titles where price between 10 and 25
select * from titles where title like '%data%';
select * from titles where pubdate<'1991-06-18 00:00:00.000'
select title as 'book name' ,price from titles where pub_id = '0877';
select title as 'book name' ,price,notes from titles where type='business' and price between 15 and 100;
select title from titles where price in (10,15,20);
select avg(price) as 'average price' from titles;

--sub total and grouping
select type 'Type name', AVG(price) 'Averge price'from titles group by type

select state, count(au_id) from authors group by state

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id
select type 'Type name', AVG(price) 'Averge price'
from titles 
where price >10
group by type
having AVG(price)>18

---sorting
select * from authors order by state,city,au_fname

select type 'Type name', AVG(price) 'Averge price'
from titles 
where price >10
group by type
having AVG(price)>18
order by Type desc

--subqueries

select * from titles
select * from sales
select title_id from titles where title = 'Straight Talk About Computers'
select * from sales where title_id = 'BU7832'

select * from sales where title_id =
(select title_id from titles where title = 'Straight Talk About Computers')

Select * from titles where title_id in(
select title_id from titleauthor where au_id = 
(select au_id from authors where au_lname = 'White'))

select title from titles where title_id in(select title_id from sales  )
--fetch the average price of titles that hvae been published by publishers 
--who are from USA. Print only if the average is greater than the average of
-- all the titles
--sort them by asencending order of the average


select title,avg(price) average_price from titles where pub_id in(
select pub_id from publishers where country ='usa') group by title having avg(price)>(select avg(price) from titles);


