print the store name, title name,, quantity, sale amount, pulisher name, author name for all the sales.
Also print those books which have not been sold and authors who have not written.

select s.stor_name,t.title,sa.qty,sa.qty*t.price sale_amount,p.pub_name,a.au_fname+' '+a.au_lname author_name 
from publishers p full join titles t on p.pub_id=t.title_id full outer join titleauthor ta on t.title_id=ta.title_id 
full outer join authors a on ta.au_id=a.au_id full join sales sa on t.title_id=sa.title_id full join stores s on sa.stor_id=s.stor_id 

create proc  pr_TotalSales(@au_fname varchar(60))
as
begin 
if exists( (select t.title,sum(s.qty*t.price) total_sales_amount from authors a join titleauthor ta on a.au_id=ta.au_id join 
titles t on ta.title_id =t.title_id join sales s on t.title_id = s.title_id where a.au_fname=@au_fname group by t.title))
begin  
select t.title,sum(s.qty*t.price) total_sales_amount from authors a join titleauthor ta on a.au_id=ta.au_id join 
titles t on ta.title_id =t.title_id join sales s on t.title_id = s.title_id where a.au_fname=@au_fname group by t.title 
end
else begin print 'sale yet to gear up'end end
exec pr_TotalSales 'johnson'

select * from sales where qty in (select  max(sales.qty) max_qty_sale from sales group by stor_id)

select a.au_fname+' '+a.au_lname Authors_full_name,avg(t.price) Average_Price_Of_This_Authors_Books from authors a left join titleauthor ta on a.au_id=ta.au_id join titles t on ta.title_id=t.title_id group by a.au_fname+' '+a.au_lname

EXEC sp_columns 'titles';


create proc pr_countOfBooksByPrice(@price float)
as
begin 
select count(title) 'No of Books Under The Given Price' from titles where price<@price
end
exec pr_countOfBooksByPrice 10.0

Find a way to ensure that the price of books are not updated if the price is below 7
create proc








select title from titles where title like '%e%a%';