// Skipping function Up(none), it contains poisonous unsupported syntaxes

func @_backend_school_api.Migrations.firstmigration.Down$Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder$(none) -> () loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :79 :8) {
^entry (%_migrationBuilder : none):
%0 = cbde.alloca none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :79 :37)
cbde.store %_migrationBuilder, %0 : memref<none> loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :79 :37)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :81 :12) // Not a variable of known type: migrationBuilder
%2 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :82 :22) // "orderlines" (StringLiteralExpression)
%3 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :81 :12) // migrationBuilder.DropTable(                  name: "orderlines") (InvocationExpression)
%4 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :84 :12) // Not a variable of known type: migrationBuilder
%5 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :85 :22) // "products" (StringLiteralExpression)
%6 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :84 :12) // migrationBuilder.DropTable(                  name: "products") (InvocationExpression)
%7 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :87 :12) // Not a variable of known type: migrationBuilder
%8 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :88 :22) // "users" (StringLiteralExpression)
%9 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :87 :12) // migrationBuilder.DropTable(                  name: "users") (InvocationExpression)
%10 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :90 :12) // Not a variable of known type: migrationBuilder
%11 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :91 :22) // "orders" (StringLiteralExpression)
%12 = cbde.unknown : none loc("C:\\Users\\quint\\Desktop\\school\\Migrations\\20201230225328_first-migration.cs" :90 :12) // migrationBuilder.DropTable(                  name: "orders") (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
