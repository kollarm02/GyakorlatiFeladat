const express = require('express');
const app = express();
const bodyParser = require('body-parser');
const mongoose = require('mongoose');
require('dotenv').config();
const cors = require('cors');

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.set('view engine', 'ejs');
app.set(express.json())
app.use(cors());
app.use( express.static( "public" ) );

const PORT = 3500;

mongoose
  .connect(process.env.MONGO_URI)
  .then(() => console.log('Sikeres csatlakozás!'))
  .catch((error) => console.log('Valami hiba történt!' + error.message));

mongoose.connection.on('open', () => console.log('Sikeres megnyitás!'));
mongoose.connection.on('close', () => console.log('Sikeres zárás!'));

const Fesztival = mongoose.model('Fesztival', {
    nev: String,
    szuletesi_datum: Date,
    telefonszam: String,
    email: String,
    foglalt_napok_szama: String,
    osszeg: String
});

app.get('/', (req, res) => {
  res.render('index');
})

app.get('/fesztivalhozzaad', (req, res) => {
  res.render('hozzaad');
});

app.post('/fesztivalhozzaad', (req, res) => {
  const nev = req.body.nev; 
  const szuletesi_datum = req.body.szuletesi_datum;
  const telefonszam = req.body.telefonszam; // javítás itt
  const email = req.body.email;
  const foglalt_napok_szama = req.body.foglalt_napok_szama; 
  const osszeg = req.body.osszeg;
  
    const fesztivalInstance = new Fesztival({ 
      nev,
      szuletesi_datum,
      telefonszam,
      email,
      foglalt_napok_szama,
      osszeg, 
    });
  
  
    fesztivalInstance.save()
      .then(() => {
        console.log('Az adatok sikeresen feltöltésre kerültek az adatbázisba')
        res.redirect('fesztivalhozzaad');
      })
      .catch(error => {
        console.log('Hiba a Fesztivál létrehozásakor:', error);
        res.status(500).send('Hiba történt a Fesztivál létrehozásakor');
      });
  });


app.get('/fesztivalkiir', (req, res) => {
    Fesztival.find()
      .then(fesztival => {
        res.render('adatok', { fesztival });
      })
      .catch(error => {
        console.log('Hiba a Fesztivál rekordok lekérdezésekor:', error);
        res.status(500).send('Hiba történt a Fesztivál rekordok lekérdezésekor');
      });
});

app.post('/fesztivaltorol/:id', (req, res) => {
  const fesztivalId = req.params.id;
  
  Fesztival.findByIdAndDelete(fesztivalId)
      .then(fesztival => {
        res.send({ fesztival });
      })
      .catch(error => {
        console.log('Hiba a Fesztivál rekord törlésekor:', error);
        res.status(500).send('Hiba történt a Fesztivál rekord törlésekor');
      });
});


app.listen(PORT, () => {
  console.log(`Server a http://localhost:${PORT}`);
});
