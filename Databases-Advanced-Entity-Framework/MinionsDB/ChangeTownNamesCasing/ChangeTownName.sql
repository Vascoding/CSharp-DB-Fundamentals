update Towns
set Name = upper(t.Name)
from Towns as t
join Countries as c
on c.Id = t.CountryId
where c.Name = @countryName