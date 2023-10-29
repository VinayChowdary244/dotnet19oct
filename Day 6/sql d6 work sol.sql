                    set 1;
select title Titles from titles;
select title Titles from titles where pub_id ='1389';
select title Titles, price from titles where price between 10 and 15;
select *  from titles where price IS NULL;
select title Titles from titles where title like 'The%';
select title Titles from titles where title not like '%V%';
select * from titles order by royalty;
select * from titles order by pub_id desc,type asc, price desc;
select avg(price) Average_Price, type as Type from titles group by type;
select distinct type from titles ;
select top 2 * from titles  order by price desc ;
select * from titles where type ='business' and price<20 and advance>7000;
select pub_id , count(title) No_of_Books from titles where title_id in(select title_id  from titles  where title_id in(select title_id from titles  where price between 15 and 25))group by pub_id having count(title)>2 order by count(title) ;
select au_fname, au_lname from authors where state ='ca';
select state , count( au_id )from authors group by state;
                        set 2;
select stor_id , count(stor_id) from sales group by stor_id;
select titles.title,count(sales.title_id) No_of_orders from titles join sales on  titles.title_id =sales.title_id group by titles.title 
select publishers.pub_name,titles.title from publishers join titles on publishers.pub_id = titles.pub_id;
select authors.au_fname+' '+authors.au_lname Authors_Full_Name from authors;
select title,price+price*12.36/100 as Price_with_tax from titles;
select authors.au_fname+' '+authors.au_lname as Author ,titles.title from authors join titleauthor on authors.au_id=titleauthor.au_id join titles on titleauthor.title_id=titles.title_id;
select authors.au_fname+' '+authors.au_lname as Author  ,titles.title,pub_name as Publisher_Name from authors join titleauthor on authors.au_id=titleauthor.au_id join titles on titleauthor.title_id=titles.title_id join publishers on titles.pub_id = publishers.pub_id;
select publishers.pub_name,avg(price) as Average_Price from publishers left join titles on publishers.pub_id = titles.pub_id group by publishers.pub_name;
select titles.title Books_Published_By_Marjorie from titles join publishers on titles.pub_id= publishers.pub_id where pub_name ='Marjorie';
select ord_num,titles.title from sales join titles on sales.title_id=titles.title_id join publishers on titles.pub_id=publishers.pub_id where pub_name ='New Moon Books';
select publishers.pub_name,count(sales.title_id) No_Of_Orders from publishers left join titles on publishers.pub_id=titles.pub_id left join sales on titles.title_id=sales.title_id group by publishers.pub_name order by No_Of_Orders desc;
select sales.ord_num,titles.title,sales.qty,titles.price,qty*price as Total from sales join titles on sales.title_id=titles.title_id;
select titles.title,sum(sales.qty) Total_Quantity_Of_Books from titles join sales on titles.title_id=sales.title_id group by titles.title;
select titles.title,(sum(sales.qty*titles.price ))Total_Order_Value from titles join sales on titles.title_id=sales.title_id group by titles.title;
select distinct sales.ord_num from sales join titles on sales.title_id=titles.title_id join publishers on titles.pub_id=publishers.pub_id join employee on publishers.pub_id=employee.pub_id where employee.fname ='paolo';



