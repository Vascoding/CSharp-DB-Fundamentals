update Minions
set Name = 
      UPPER(LEFT(Name, 1)) +
        LOWER(RIGHT(Name, LEN(Name) - 1))
		where Id in (@MinionsID)
update Minions
set Age = Age + 1
where Id in (@MinionsID)