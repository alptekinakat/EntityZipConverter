# EntityZipConverter

Net Entity binary fields zip converter

Use

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  ...
    modelBuilder.Entity<MODEL>().Property(e => e.BINARY_FIELD).HasConversion(PersolusDb.Helper.ZipConverter.ValueConverter);
  ...
}
```
