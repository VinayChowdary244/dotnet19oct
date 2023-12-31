
select st.stor_name StoreName,t.title Title,s.qty Quantity,s.qty * t.price SaleAmount,p.pub_name PublisherName,
concat(au.au_fname, ' ', au.au_lname) as AuthorName,'Sold' as 'Status'
from sales s join stores st ON s.stor_id = st.stor_id join titles t ON s.title_id = t.title_id join 
publishers p ON t.pub_id = p.pub_id left join titleauthor ta ON t.title_id = ta.title_id left join authors au ON ta.au_id = au.au_id
union all
select t.title Title,p.pub_name PublisherName,null Quantity,null SaleAmount,null StoreName,concat(au.au_fname, ' ', au.au_lname) 
AuthorName,'Not Sold' as 'Status'
from titles t join publishers p ON t.pub_id = p.pub_id left join titleauthor ta ON t.title_id = ta.title_id 
left join authors au ON ta.au_id = au.au_id
union all
select null StoreName,null Title,null Quantity,null SaleAmount,null PublisherName,concat(au.au_fname, ' ', au.au_lname) AuthorName,
    'Not Written' as 'Status'
from authors au left join titleauthor ta ON au.au_id = ta.au_id;





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


create proc pr_update(@title_id varchar(10),@price float)
as
begin
if((select price from titles where title_id =@title_id)<7)
begin
print'Price not updated as it is below 7'
end
else begin
update titles set price=@price where title_id=@title_id
end
end
exec pr_update 'bu2075' ,100
select * from titles


select title from titles where title like '%e%a%';