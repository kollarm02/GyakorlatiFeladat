const express = require('express');
const sqlite3 = require('sqlite3').verbose();

const app = express();
const PORT = process.env.PORT || 3000;
const DB_PATH = './tags.db';

const db = new sqlite3.Database(DB_PATH, (err) => {
  if (err) {
    console.error('Error connecting to database:', err.message);
  } else {
    console.log('Connected to the database.');
    db.run(`CREATE TABLE IF NOT EXISTS tags (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      last_name TEXT,
      first_name TEXT,
      workplace TEXT,
      email TEXT
    )`);
  }
});

app.use(express.json());

// CREATE
app.post('/new', (req, res) => {
  const { last_name, first_name, workplace, email } = req.body;
  const sql = `INSERT INTO tags (last_name, first_name, workplace, email) VALUES (?, ?, ?, ?)`;
  db.run(sql, [last_name, first_name, workplace, email], function(err) {
    if (err) {
      console.error('Error inserting data:', err.message);
      res.status(500).json({ error: 'Failed to create tag' });
    } else {
      res.status(201).json({ id: this.lastID });
    }
  });
});

// READ
app.get('/read', (req, res) => {
  const sql = `SELECT * FROM tags`;
  db.all(sql, [], (err, rows) => {
    if (err) {
      console.error('Error reading data:', err.message);
      res.status(500).json({ error: 'Failed to read tags' });
    } else {
      res.json(rows);
    }
  });
});

// UPDATE
app.put('/upd/:id', (req, res) => {
  const { last_name, first_name, workplace, email } = req.body;
  const id = req.params.id;
  const sql = `UPDATE tags SET last_name = ?, first_name = ?, workplace = ?, email = ? WHERE id = ?`;
  db.run(sql, [last_name, first_name, workplace, email, id], function(err) {
    if (err) {
      console.error('Error updating data:', err.message);
      res.status(500).json({ error: 'Failed to update tag' });
    } else {
      res.sendStatus(200);
    }
  });
});

// DELETE
app.delete('/del/:id', (req, res) => {
  const id = req.params.id;
  const sql = `DELETE FROM tags WHERE id = ?`;
  db.run(sql, [id], function(err) {
    if (err) {
      console.error('Error deleting data:', err.message);
      res.status(500).json({ error: 'Failed to delete tag' });
    } else {
      res.sendStatus(204);
    }
  });
});

// Start server
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
