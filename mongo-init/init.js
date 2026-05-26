// ─────────────────────────────────────────────
// Script de inicialização do MongoDB
// Executado automaticamente na primeira vez que o container sobe
// ─────────────────────────────────────────────

db = db.getSiblingDB('autoprimemotors');

db.createCollection('veiculos');
db.createCollection('clientes');
db.createCollection('usuarios');

// Índices para performance e unicidade
db.veiculos.createIndex({ status: 1 });
db.veiculos.createIndex({ marca: 1, modelo: 1 });
db.veiculos.createIndex({ preco: 1 });

db.clientes.createIndex({ email: 1 }, { unique: true });
db.clientes.createIndex({ cpf: 1 }, { unique: true });

db.usuarios.createIndex({ email: 1 }, { unique: true });

print('✅ AutoPrime Motors — Banco de dados inicializado com sucesso!');
print('   Collections criadas: veiculos, clientes, usuarios');
print('   Índices configurados.');
