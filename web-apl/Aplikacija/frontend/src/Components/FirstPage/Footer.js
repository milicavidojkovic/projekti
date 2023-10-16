import React from 'react';
import { FaInstagram } from 'react-icons/fa';
import './Footer.css'; // Import the CSS file for styling

export default function Footer() {
  const currentYear = new Date().getFullYear();

  return (
    <footer>
      <div className="footer-container">
        <div className="left-section">
          <span className="logo">SmartWalls</span>
          <span className="copy-right">
            &copy; {currentYear} SmartWalls. All rights reserved.
          </span>
        </div>
        <div className="right-section">
          <span className="contact-info">
            Instagram: 
            <a
              href="https://www.instagram.com"
              target="_blank"
              rel="noopener noreferrer"
              className="instagram-link"
            >
              <FaInstagram className="instagram-icon" />
            </a>
          </span>
          <span className="contact-info">Telefon: +381 66 42 11 48</span>
        </div>
      </div>
    </footer>
  );
}


// import React from 'react';
// import { FaRocket, FaMapMarkerAlt, FaPhoneAlt, FaEnvelope } from 'react-icons/fa';
// import { AiOutlineInstagram, AiOutlineFacebook, AiOutlineTwitter, AiOutlineYoutube } from 'react-icons/ai';

// function Footer() {
//   return (
//     <footer id="kontakt" style={{ backgroundColor: '#f8f8f8', padding: '20px' }}>
//       <iframe
//         title="myframe"
//         src="https://www.google.com/maps/d/u/0/embed?mid=1SrPunC-1NDr-HbykEFIFLaYmk35r8F0&ehbc=2E312F" 
//         width="640" height="480"
//         width="100%"
//         height="240"
//         style={{ border: '2px solid', marginBottom: '2vh' }}
//         allowFullScreen
//       />

//       <div style={{ display: 'flex', justifyContent: 'center', marginBottom: '2vh' }}>
//         <FaRocket style={{ marginRight: '10px' }} />
//         <h6 style={{ marginRight: '20px', fontFamily: 'monospace', fontWeight: 700, letterSpacing: '.2rem' }}>
//           RaketaDoLeta
//         </h6>
//         <div style={{ display: 'flex' }}>
//           <a href="https://instagram.com" target="_blank" rel="noopener noreferrer">
//             <AiOutlineInstagram />
//           </a>
//           <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">
//             <AiOutlineTwitter />
//           </a>
//           <a href="https://facebook.com" target="_blank" rel="noopener noreferrer">
//             <AiOutlineFacebook />
//           </a>
//           <a href="https://youtube.com" target="_blank" rel="noopener noreferrer">
//             <AiOutlineYoutube />
//           </a>
//         </div>
//       </div>

//       <div style={{ display: 'flex', justifyContent: 'space-between' }}>
//         <div style={{ flex: 1 }}>
//           <div style={{ borderBottom: '1px solid black', marginBottom: '2%' }}>Kontaktirajte nas:</div>
//           <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'center', marginTop: '2%' }}>
//             <FaMapMarkerAlt />
//             <a href="https://goo.gl/maps/KMwmrKHLCjQdkbaW6" target="_blank" rel="noopener noreferrer">
//               <p style={{ marginLeft: '2%', fontSize: 'caption', color: 'black' }}>Sremska 8</p>
//             </a>
//           </div>
//           <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'center' }}>
//             <FaEnvelope />
//             <p style={{ marginLeft: '2%', fontSize: 'caption', color: 'black' }}>smartwalls@gmail.com</p>
//           </div>
//           <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'center' }}>
//             <FaPhoneAlt />
//             <p style={{ marginLeft: '2%', fontSize: 'caption', color: 'black' }}>+381 66 421148</p>
//           </div>
//         </div>
//       </div> 
//       <div style={{ textAlign: 'center', marginTop: '2vh' }}>
//         {'© '}
//         <a href='http://localhost:3000/' style={{ textDecoration: 'none' }}>
//           SmartWalls
//         </a>{' '}
//         {new Date().getFullYear()}
//         {'.'}
//       </div>
//     </footer>
//   );
// }

// export default Footer;