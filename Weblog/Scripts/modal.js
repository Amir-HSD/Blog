
// The MIT License (MIT)

// modal.js | Copyright (c) 2017 Shahzaib Khalid | www.shahzaibkhalid.com

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
           const head = document.getElementsByTagName('head')[0];
            const animationsCSSStyleTag = document.createElement('style');
            const modalCSSStyleTag = document.createElement('style');
            let classesToHide;
            let classesToRetainOriginal;
            let modal, modalContent;
  
            /*
              This valuesObj is only for your reference for what you've chosen when you downloaded from website.
              Changing this won't effect anything. Please refer comments below to modify: 
                1) HTML inside the modal
                2) Input CSS animation tag, e.g. bounceInDown (at 2 places)
                3) Output CSS animation name, e.g. bounceOutDown (at 1 place)
            */
  
            let valuesObj = {
              $modalHTML: `<h1 class="main-heading">Hello world</h1>
<h2>Welcome to modal.js editor.</h2>
<h3 class="third-heading">Edit me to put whatever you want.</h3>`,
              $inputAnimation: 'bounce',
              $outputAnimation: 'bounce',
              $modalCSS: `.modal {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.4);
    overflow:auto;
}

.modal-content-area {
    background-color: white;
    margin: 15% auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
    border-radius: 10px;
    box-shadow: 5px 5px 25px 0px rgba(46, 61, 73, 0.2);
}

.close-button {
    cursor: pointer;
    color: white;
    background-color: rosybrown;
    border-radius: 30%;
    padding: 5px;
    font-family: 'Arial', sans-serif;
    font-style: normal;
}

.main-heading {
  color: rosybrown;
}
.third-heading {
  color: pink;
}
`
            };
  
            let $animationCSS = `@charset "UTF-8";
          .animated {
            animation-duration: 1s;
            animation-fill-mode: both;
          }
  
          .animated.infinite {
            animation-iteration-count: infinite;
          }
  
          .animated.hinge {
            animation-duration: 2s;
          }
  
          .animated.flipOutX,
          .animated.flipOutY,
          .animated.bounceIn,
          .animated.bounceOut {
            animation-duration: .75s;
          }
  
          @keyframes bounce {
            from, 20%, 53%, 80%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
              transform: translate3d(0,0,0);
            }
  
            40%, 43% {
              animation-timing-function: cubic-bezier(0.755, 0.050, 0.855, 0.060);
              transform: translate3d(0, -30px, 0);
            }
  
            70% {
              animation-timing-function: cubic-bezier(0.755, 0.050, 0.855, 0.060);
              transform: translate3d(0, -15px, 0);
            }
  
            90% {
              transform: translate3d(0,-4px,0);
            }
          }
  
          .bounce {
            animation-name: bounce;
            transform-origin: center bottom;
          }
  
          @keyframes flash {
            from, 50%, to {
              opacity: 1;
            }
  
            25%, 75% {
              opacity: 0;
            }
          }
  
          .flash {
            animation-name: flash;
          }
  
  
          @keyframes pulse {
            from {
              transform: scale3d(1, 1, 1);
            }
  
            50% {
              transform: scale3d(1.05, 1.05, 1.05);
            }
  
            to {
              transform: scale3d(1, 1, 1);
            }
          }
  
          .pulse {
            animation-name: pulse;
          }
  
          @keyframes rubberBand {
            from {
              transform: scale3d(1, 1, 1);
            }
  
            30% {
              transform: scale3d(1.25, 0.75, 1);
            }
  
            40% {
              transform: scale3d(0.75, 1.25, 1);
            }
  
            50% {
              transform: scale3d(1.15, 0.85, 1);
            }
  
            65% {
              transform: scale3d(.95, 1.05, 1);
            }
  
            75% {
              transform: scale3d(1.05, .95, 1);
            }
  
            to {
              transform: scale3d(1, 1, 1);
            }
          }
  
          .rubberBand {
            animation-name: rubberBand;
          }
  
          @keyframes shake {
            from, to {
              transform: translate3d(0, 0, 0);
            }
  
            10%, 30%, 50%, 70%, 90% {
              transform: translate3d(-10px, 0, 0);
            }
  
            20%, 40%, 60%, 80% {
              transform: translate3d(10px, 0, 0);
            }
          }
  
          .shake {
            animation-name: shake;
          }
  
          @keyframes headShake {
            0% {
              transform: translateX(0);
            }
  
            6.5% {
              transform: translateX(-6px) rotateY(-9deg);
            }
  
            18.5% {
              transform: translateX(5px) rotateY(7deg);
            }
  
            31.5% {
              transform: translateX(-3px) rotateY(-5deg);
            }
  
            43.5% {
              transform: translateX(2px) rotateY(3deg);
            }
  
            50% {
              transform: translateX(0);
            }
          }
  
          .headShake {
            animation-timing-function: ease-in-out;
            animation-name: headShake;
          }
  
          @keyframes swing {
            20% {
              transform: rotate3d(0, 0, 1, 15deg);
            }
  
            40% {
              transform: rotate3d(0, 0, 1, -10deg);
            }
  
            60% {
              transform: rotate3d(0, 0, 1, 5deg);
            }
  
            80% {
              transform: rotate3d(0, 0, 1, -5deg);
            }
  
            to {
              transform: rotate3d(0, 0, 1, 0deg);
            }
          }
  
          .swing {
            transform-origin: top center;
            animation-name: swing;
          }
  
          @keyframes tada {
            from {
              transform: scale3d(1, 1, 1);
            }
  
            10%, 20% {
              transform: scale3d(.9, .9, .9) rotate3d(0, 0, 1, -3deg);
            }
  
            30%, 50%, 70%, 90% {
              transform: scale3d(1.1, 1.1, 1.1) rotate3d(0, 0, 1, 3deg);
            }
  
            40%, 60%, 80% {
              transform: scale3d(1.1, 1.1, 1.1) rotate3d(0, 0, 1, -3deg);
            }
  
            to {
              transform: scale3d(1, 1, 1);
            }
          }
  
          .tada {
            animation-name: tada;
          }
  
          /* originally authored by Nick Pettit - https://github.com/nickpettit/glide */
  
          @keyframes wobble {
            from {
              transform: none;
            }
  
            15% {
              transform: translate3d(-25%, 0, 0) rotate3d(0, 0, 1, -5deg);
            }
  
            30% {
              transform: translate3d(20%, 0, 0) rotate3d(0, 0, 1, 3deg);
            }
  
            45% {
              transform: translate3d(-15%, 0, 0) rotate3d(0, 0, 1, -3deg);
            }
  
            60% {
              transform: translate3d(10%, 0, 0) rotate3d(0, 0, 1, 2deg);
            }
  
            75% {
              transform: translate3d(-5%, 0, 0) rotate3d(0, 0, 1, -1deg);
            }
  
            to {
              transform: none;
            }
          }
  
          .wobble {
            animation-name: wobble;
          }
  
          @keyframes jello {
            from, 11.1%, to {
              transform: none;
            }
  
            22.2% {
              transform: skewX(-12.5deg) skewY(-12.5deg);
            }
  
            33.3% {
              transform: skewX(6.25deg) skewY(6.25deg);
            }
  
            44.4% {
              transform: skewX(-3.125deg) skewY(-3.125deg);
            }
  
            55.5% {
              transform: skewX(1.5625deg) skewY(1.5625deg);
            }
  
            66.6% {
              transform: skewX(-0.78125deg) skewY(-0.78125deg);
            }
  
            77.7% {
              transform: skewX(0.390625deg) skewY(0.390625deg);
            }
  
            88.8% {
              transform: skewX(-0.1953125deg) skewY(-0.1953125deg);
            }
          }
  
          .jello {
            animation-name: jello;
            transform-origin: center;
          }
  
          @keyframes bounceIn {
            from, 20%, 40%, 60%, 80%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
            }
  
            0% {
              opacity: 0;
              transform: scale3d(.3, .3, .3);
            }
  
            20% {
              transform: scale3d(1.1, 1.1, 1.1);
            }
  
            40% {
              transform: scale3d(.9, .9, .9);
            }
  
            60% {
              opacity: 1;
              transform: scale3d(1.03, 1.03, 1.03);
            }
  
            80% {
              transform: scale3d(.97, .97, .97);
            }
  
            to {
              opacity: 1;
              transform: scale3d(1, 1, 1);
            }
          }
  
          .bounceIn {
            animation-name: bounceIn;
          }
  
          @keyframes bounceInDown {
            from, 60%, 75%, 90%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
            }
  
            0% {
              opacity: 0;
              transform: translate3d(0, -3000px, 0);
            }
  
            60% {
              opacity: 1;
              transform: translate3d(0, 25px, 0);
            }
  
            75% {
              transform: translate3d(0, -10px, 0);
            }
  
            90% {
              transform: translate3d(0, 5px, 0);
            }
  
            to {
              transform: none;
            }
          }
  
          .bounceInDown {
            animation-name: bounceInDown;
          }
  
          @keyframes bounceInLeft {
            from, 60%, 75%, 90%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
            }
  
            0% {
              opacity: 0;
              transform: translate3d(-3000px, 0, 0);
            }
  
            60% {
              opacity: 1;
              transform: translate3d(25px, 0, 0);
            }
  
            75% {
              transform: translate3d(-10px, 0, 0);
            }
  
            90% {
              transform: translate3d(5px, 0, 0);
            }
  
            to {
              transform: none;
            }
          }
  
          .bounceInLeft {
            animation-name: bounceInLeft;
          }
  
          @keyframes bounceInRight {
            from, 60%, 75%, 90%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
            }
  
            from {
              opacity: 0;
              transform: translate3d(3000px, 0, 0);
            }
  
            60% {
              opacity: 1;
              transform: translate3d(-25px, 0, 0);
            }
  
            75% {
              transform: translate3d(10px, 0, 0);
            }
  
            90% {
              transform: translate3d(-5px, 0, 0);
            }
  
            to {
              transform: none;
            }
          }
  
          .bounceInRight {
            animation-name: bounceInRight;
          }
  
          @keyframes bounceInUp {
            from, 60%, 75%, 90%, to {
              animation-timing-function: cubic-bezier(0.215, 0.610, 0.355, 1.000);
            }
  
            from {
              opacity: 0;
              transform: translate3d(0, 3000px, 0);
            }
  
            60% {
              opacity: 1;
              transform: translate3d(0, -20px, 0);
            }
  
            75% {
              transform: translate3d(0, 10px, 0);
            }
  
            90% {
              transform: translate3d(0, -5px, 0);
            }
  
            to {
              transform: translate3d(0, 0, 0);
            }
          }
  
          .bounceInUp {
            animation-name: bounceInUp;
          }
  
          @keyframes bounceOut {
            20% {
              transform: scale3d(.9, .9, .9);
            }
  
            50%, 55% {
              opacity: 1;
              transform: scale3d(1.1, 1.1, 1.1);
            }
  
            to {
              opacity: 0;
              transform: scale3d(.3, .3, .3);
            }
          }
  
          .bounceOut {
            animation-name: bounceOut;
          }
  
          @keyframes bounceOutDown {
            20% {
              transform: translate3d(0, 10px, 0);
            }
  
            40%, 45% {
              opacity: 1;
              transform: translate3d(0, -20px, 0);
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, 2000px, 0);
            }
          }
  
          .bounceOutDown {
            animation-name: bounceOutDown;
          }
  
          @keyframes bounceOutLeft {
            20% {
              opacity: 1;
              transform: translate3d(20px, 0, 0);
            }
  
            to {
              opacity: 0;
              transform: translate3d(-2000px, 0, 0);
            }
          }
  
          .bounceOutLeft {
            animation-name: bounceOutLeft;
          }
  
          @keyframes bounceOutRight {
            20% {
              opacity: 1;
              transform: translate3d(-20px, 0, 0);
            }
  
            to {
              opacity: 0;
              transform: translate3d(2000px, 0, 0);
            }
          }
  
          .bounceOutRight {
            animation-name: bounceOutRight;
          }
  
          @keyframes bounceOutUp {
            20% {
              transform: translate3d(0, -10px, 0);
            }
  
            40%, 45% {
              opacity: 1;
              transform: translate3d(0, 20px, 0);
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, -2000px, 0);
            }
          }
  
          .bounceOutUp {
            animation-name: bounceOutUp;
          }
  
          @keyframes fadeIn {
            from {
              opacity: 0;
            }
  
            to {
              opacity: 1;
            }
          }
  
          .fadeIn {
            animation-name: fadeIn;
          }
  
          @keyframes fadeInDown {
            from {
              opacity: 0;
              transform: translate3d(0, -100%, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInDown {
            animation-name: fadeInDown;
          }
  
          @keyframes fadeInDownBig {
            from {
              opacity: 0;
              transform: translate3d(0, -2000px, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInDownBig {
            animation-name: fadeInDownBig;
          }
  
          @keyframes fadeInLeft {
            from {
              opacity: 0;
              transform: translate3d(-100%, 0, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInLeft {
            animation-name: fadeInLeft;
          }
  
          @keyframes fadeInLeftBig {
            from {
              opacity: 0;
              transform: translate3d(-2000px, 0, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInLeftBig {
            animation-name: fadeInLeftBig;
          }
  
          @keyframes fadeInRight {
            from {
              opacity: 0;
              transform: translate3d(100%, 0, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInRight {
            animation-name: fadeInRight;
          }
  
          @keyframes fadeInRightBig {
            from {
              opacity: 0;
              transform: translate3d(2000px, 0, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInRightBig {
            animation-name: fadeInRightBig;
          }
  
          @keyframes fadeInUp {
            from {
              opacity: 0;
              transform: translate3d(0, 100%, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInUp {
            animation-name: fadeInUp;
          }
  
          @keyframes fadeInUpBig {
            from {
              opacity: 0;
              transform: translate3d(0, 2000px, 0);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .fadeInUpBig {
            animation-name: fadeInUpBig;
          }
  
          @keyframes fadeOut {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
            }
          }
  
          .fadeOut {
            animation-name: fadeOut;
          }
  
          @keyframes fadeOutDown {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, 100%, 0);
            }
          }
  
          .fadeOutDown {
            animation-name: fadeOutDown;
          }
  
          @keyframes fadeOutDownBig {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, 2000px, 0);
            }
          }
  
          .fadeOutDownBig {
            animation-name: fadeOutDownBig;
          }
  
          @keyframes fadeOutLeft {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(-100%, 0, 0);
            }
          }
  
          .fadeOutLeft {
            animation-name: fadeOutLeft;
          }
  
          @keyframes fadeOutLeftBig {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(-2000px, 0, 0);
            }
          }
  
          .fadeOutLeftBig {
            animation-name: fadeOutLeftBig;
          }
  
          @keyframes fadeOutRight {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(100%, 0, 0);
            }
          }
  
          .fadeOutRight {
            animation-name: fadeOutRight;
          }
  
          @keyframes fadeOutRightBig {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(2000px, 0, 0);
            }
          }
  
          .fadeOutRightBig {
            animation-name: fadeOutRightBig;
          }
  
          @keyframes fadeOutUp {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, -100%, 0);
            }
          }
  
          .fadeOutUp {
            animation-name: fadeOutUp;
          }
  
          @keyframes fadeOutUpBig {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(0, -2000px, 0);
            }
          }
  
          .fadeOutUpBig {
            animation-name: fadeOutUpBig;
          }
  
          @keyframes flip {
            from {
              transform: perspective(400px) rotate3d(0, 1, 0, -360deg);
              animation-timing-function: ease-out;
            }
  
            40% {
              transform: perspective(400px) translate3d(0, 0, 150px) rotate3d(0, 1, 0, -190deg);
              animation-timing-function: ease-out;
            }
  
            50% {
              transform: perspective(400px) translate3d(0, 0, 150px) rotate3d(0, 1, 0, -170deg);
              animation-timing-function: ease-in;
            }
  
            80% {
              transform: perspective(400px) scale3d(.95, .95, .95);
              animation-timing-function: ease-in;
            }
  
            to {
              transform: perspective(400px);
              animation-timing-function: ease-in;
            }
          }
  
          .animated.flip {
            -webkit-backface-visibility: visible;
            backface-visibility: visible;
            animation-name: flip;
          }
  
          @keyframes flipInX {
            from {
              transform: perspective(400px) rotate3d(1, 0, 0, 90deg);
              animation-timing-function: ease-in;
              opacity: 0;
            }
  
            40% {
              transform: perspective(400px) rotate3d(1, 0, 0, -20deg);
              animation-timing-function: ease-in;
            }
  
            60% {
              transform: perspective(400px) rotate3d(1, 0, 0, 10deg);
              opacity: 1;
            }
  
            80% {
              transform: perspective(400px) rotate3d(1, 0, 0, -5deg);
            }
  
            to {
              transform: perspective(400px);
            }
          }
  
          .flipInX {
            -webkit-backface-visibility: visible !important;
            backface-visibility: visible !important;
            animation-name: flipInX;
          }
  
          @keyframes flipInY {
            from {
              transform: perspective(400px) rotate3d(0, 1, 0, 90deg);
              animation-timing-function: ease-in;
              opacity: 0;
            }
  
            40% {
              transform: perspective(400px) rotate3d(0, 1, 0, -20deg);
              animation-timing-function: ease-in;
            }
  
            60% {
              transform: perspective(400px) rotate3d(0, 1, 0, 10deg);
              opacity: 1;
            }
  
            80% {
              transform: perspective(400px) rotate3d(0, 1, 0, -5deg);
            }
  
            to {
              transform: perspective(400px);
            }
          }
  
          .flipInY {
            -webkit-backface-visibility: visible !important;
            backface-visibility: visible !important;
            animation-name: flipInY;
          }
  
          @keyframes flipOutX {
            from {
              transform: perspective(400px);
            }
  
            30% {
              transform: perspective(400px) rotate3d(1, 0, 0, -20deg);
              opacity: 1;
            }
  
            to {
              transform: perspective(400px) rotate3d(1, 0, 0, 90deg);
              opacity: 0;
            }
          }
  
          .flipOutX {
            animation-name: flipOutX;
            -webkit-backface-visibility: visible !important;
            backface-visibility: visible !important;
          }
  
          @keyframes flipOutY {
            from {
              transform: perspective(400px);
            }
  
            30% {
              transform: perspective(400px) rotate3d(0, 1, 0, -15deg);
              opacity: 1;
            }
  
            to {
              transform: perspective(400px) rotate3d(0, 1, 0, 90deg);
              opacity: 0;
            }
          }
  
          .flipOutY {
            -webkit-backface-visibility: visible !important;
            backface-visibility: visible !important;
            animation-name: flipOutY;
          }
  
          @keyframes lightSpeedIn {
            from {
              transform: translate3d(100%, 0, 0) skewX(-30deg);
              opacity: 0;
            }
  
            60% {
              transform: skewX(20deg);
              opacity: 1;
            }
  
            80% {
              transform: skewX(-5deg);
              opacity: 1;
            }
  
            to {
              transform: none;
              opacity: 1;
            }
          }
  
          .lightSpeedIn {
            animation-name: lightSpeedIn;
            animation-timing-function: ease-out;
          }
  
          @keyframes lightSpeedOut {
            from {
              opacity: 1;
            }
  
            to {
              transform: translate3d(100%, 0, 0) skewX(30deg);
              opacity: 0;
            }
          }
  
          .lightSpeedOut {
            animation-name: lightSpeedOut;
            animation-timing-function: ease-in;
          }
  
          @keyframes rotateIn {
            from {
              transform-origin: center;
              transform: rotate3d(0, 0, 1, -200deg);
              opacity: 0;
            }
  
            to {
              transform-origin: center;
              transform: none;
              opacity: 1;
            }
          }
  
          .rotateIn {
            animation-name: rotateIn;
          }
  
          @keyframes rotateInDownLeft {
            from {
              transform-origin: left bottom;
              transform: rotate3d(0, 0, 1, -45deg);
              opacity: 0;
            }
  
            to {
              transform-origin: left bottom;
              transform: none;
              opacity: 1;
            }
          }
  
          .rotateInDownLeft {
            animation-name: rotateInDownLeft;
          }
  
          @keyframes rotateInDownRight {
            from {
              transform-origin: right bottom;
              transform: rotate3d(0, 0, 1, 45deg);
              opacity: 0;
            }
  
            to {
              transform-origin: right bottom;
              transform: none;
              opacity: 1;
            }
          }
  
          .rotateInDownRight {
            animation-name: rotateInDownRight;
          }
  
          @keyframes rotateInUpLeft {
            from {
              transform-origin: left bottom;
              transform: rotate3d(0, 0, 1, 45deg);
              opacity: 0;
            }
  
            to {
              transform-origin: left bottom;
              transform: none;
              opacity: 1;
            }
          }
  
          .rotateInUpLeft {
            animation-name: rotateInUpLeft;
          }
  
          @keyframes rotateInUpRight {
            from {
              transform-origin: right bottom;
              transform: rotate3d(0, 0, 1, -90deg);
              opacity: 0;
            }
  
            to {
              transform-origin: right bottom;
              transform: none;
              opacity: 1;
            }
          }
  
          .rotateInUpRight {
            animation-name: rotateInUpRight;
          }
  
          @keyframes rotateOut {
            from {
              transform-origin: center;
              opacity: 1;
            }
  
            to {
              transform-origin: center;
              transform: rotate3d(0, 0, 1, 200deg);
              opacity: 0;
            }
          }
  
          .rotateOut {
            animation-name: rotateOut;
          }
  
          @keyframes rotateOutDownLeft {
            from {
              transform-origin: left bottom;
              opacity: 1;
            }
  
            to {
              transform-origin: left bottom;
              transform: rotate3d(0, 0, 1, 45deg);
              opacity: 0;
            }
          }
  
          .rotateOutDownLeft {
            animation-name: rotateOutDownLeft;
          }
  
          @keyframes rotateOutDownRight {
            from {
              transform-origin: right bottom;
              opacity: 1;
            }
  
            to {
              transform-origin: right bottom;
              transform: rotate3d(0, 0, 1, -45deg);
              opacity: 0;
            }
          }
  
          .rotateOutDownRight {
            animation-name: rotateOutDownRight;
          }
  
          @keyframes rotateOutUpLeft {
            from {
              transform-origin: left bottom;
              opacity: 1;
            }
  
            to {
              transform-origin: left bottom;
              transform: rotate3d(0, 0, 1, -45deg);
              opacity: 0;
            }
          }
  
          .rotateOutUpLeft {
            animation-name: rotateOutUpLeft;
          }
  
          @keyframes rotateOutUpRight {
            from {
              transform-origin: right bottom;
              opacity: 1;
            }
  
            to {
              transform-origin: right bottom;
              transform: rotate3d(0, 0, 1, 90deg);
              opacity: 0;
            }
          }
  
          .rotateOutUpRight {
            animation-name: rotateOutUpRight;
          }
  
          @keyframes hinge {
            0% {
              transform-origin: top left;
              animation-timing-function: ease-in-out;
            }
  
            20%, 60% {
              transform: rotate3d(0, 0, 1, 80deg);
              transform-origin: top left;
              animation-timing-function: ease-in-out;
            }
  
            40%, 80% {
              transform: rotate3d(0, 0, 1, 60deg);
              transform-origin: top left;
              animation-timing-function: ease-in-out;
              opacity: 1;
            }
  
            to {
              transform: translate3d(0, 700px, 0);
              opacity: 0;
            }
          }
  
          .hinge {
            animation-name: hinge;
          }
  
          @keyframes jackInTheBox {
            from {
              opacity: 0;
              transform: scale(0.1) rotate(30deg);
              transform-origin: center bottom;
            }
  
            50% {
              transform: rotate(-10deg);
            }
  
            70% {
              transform: rotate(3deg);
            }
  
            to {
              opacity: 1;
              transform: scale(1);
            }
          }
  
          .jackInTheBox {
            animation-name: jackInTheBox;
          }
  
          /* originally authored by Nick Pettit - https://github.com/nickpettit/glide */
  
          @keyframes rollIn {
            from {
              opacity: 0;
              transform: translate3d(-100%, 0, 0) rotate3d(0, 0, 1, -120deg);
            }
  
            to {
              opacity: 1;
              transform: none;
            }
          }
  
          .rollIn {
            animation-name: rollIn;
          }
  
          /* originally authored by Nick Pettit - https://github.com/nickpettit/glide */
  
          @keyframes rollOut {
            from {
              opacity: 1;
            }
  
            to {
              opacity: 0;
              transform: translate3d(100%, 0, 0) rotate3d(0, 0, 1, 120deg);
            }
          }
  
          .rollOut {
            animation-name: rollOut;
          }
  
          @keyframes zoomIn {
            from {
              opacity: 0;
              transform: scale3d(.3, .3, .3);
            }
  
            50% {
              opacity: 1;
            }
          }
  
          .zoomIn {
            animation-name: zoomIn;
          }
  
          @keyframes zoomInDown {
            from {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(0, -1000px, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            60% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(0, 60px, 0);
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomInDown {
            animation-name: zoomInDown;
          }
  
          @keyframes zoomInLeft {
            from {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(-1000px, 0, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            60% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(10px, 0, 0);
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomInLeft {
            animation-name: zoomInLeft;
          }
  
          @keyframes zoomInRight {
            from {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(1000px, 0, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            60% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(-10px, 0, 0);
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomInRight {
            animation-name: zoomInRight;
          }
  
          @keyframes zoomInUp {
            from {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(0, 1000px, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            60% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(0, -60px, 0);
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomInUp {
            animation-name: zoomInUp;
          }
  
          @keyframes zoomOut {
            from {
              opacity: 1;
            }
  
            50% {
              opacity: 0;
              transform: scale3d(.3, .3, .3);
            }
  
            to {
              opacity: 0;
            }
          }
  
          .zoomOut {
            animation-name: zoomOut;
          }
  
          @keyframes zoomOutDown {
            40% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(0, -60px, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            to {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(0, 2000px, 0);
              transform-origin: center bottom;
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomOutDown {
            animation-name: zoomOutDown;
          }
  
          @keyframes zoomOutLeft {
            40% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(42px, 0, 0);
            }
  
            to {
              opacity: 0;
              transform: scale(.1) translate3d(-2000px, 0, 0);
              transform-origin: left center;
            }
          }
  
          .zoomOutLeft {
            animation-name: zoomOutLeft;
          }
  
          @keyframes zoomOutRight {
            40% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(-42px, 0, 0);
            }
  
            to {
              opacity: 0;
              transform: scale(.1) translate3d(2000px, 0, 0);
              transform-origin: right center;
            }
          }
  
          .zoomOutRight {
            animation-name: zoomOutRight;
          }
  
          @keyframes zoomOutUp {
            40% {
              opacity: 1;
              transform: scale3d(.475, .475, .475) translate3d(0, 60px, 0);
              animation-timing-function: cubic-bezier(0.550, 0.055, 0.675, 0.190);
            }
  
            to {
              opacity: 0;
              transform: scale3d(.1, .1, .1) translate3d(0, -2000px, 0);
              transform-origin: center bottom;
              animation-timing-function: cubic-bezier(0.175, 0.885, 0.320, 1);
            }
          }
  
          .zoomOutUp {
            animation-name: zoomOutUp;
          }
  
          @keyframes slideInDown {
            from {
              transform: translate3d(0, -100%, 0);
              visibility: visible;
            }
  
            to {
              transform: translate3d(0, 0, 0);
            }
          }
  
          .slideInDown {
            animation-name: slideInDown;
          }
  
          @keyframes slideInLeft {
            from {
              transform: translate3d(-100%, 0, 0);
              visibility: visible;
            }
  
            to {
              transform: translate3d(0, 0, 0);
            }
          }
  
          .slideInLeft {
            animation-name: slideInLeft;
          }
  
          @keyframes slideInRight {
            from {
              transform: translate3d(100%, 0, 0);
              visibility: visible;
            }
  
            to {
              transform: translate3d(0, 0, 0);
            }
          }
  
          .slideInRight {
            animation-name: slideInRight;
          }
  
          @keyframes slideInUp {
            from {
              transform: translate3d(0, 100%, 0);
              visibility: visible;
            }
  
            to {
              transform: translate3d(0, 0, 0);
            }
          }
  
          .slideInUp {
            animation-name: slideInUp;
          }
  
          @keyframes slideOutDown {
            from {
              transform: translate3d(0, 0, 0);
            }
  
            to {
              visibility: hidden;
              transform: translate3d(0, 100%, 0);
            }
          }
  
          .slideOutDown {
            animation-name: slideOutDown;
          }
  
          @keyframes slideOutLeft {
            from {
              transform: translate3d(0, 0, 0);
            }
  
            to {
              visibility: hidden;
              transform: translate3d(-100%, 0, 0);
            }
          }
  
          .slideOutLeft {
            animation-name: slideOutLeft;
          }
  
          @keyframes slideOutRight {
            from {
              transform: translate3d(0, 0, 0);
            }
  
            to {
              visibility: hidden;
              transform: translate3d(100%, 0, 0);
            }
          }
  
          .slideOutRight {
            animation-name: slideOutRight;
          }
  
          @keyframes slideOutUp {
            from {
              transform: translate3d(0, 0, 0);
            }
  
            to {
              visibility: hidden;
              transform: translate3d(0, -100%, 0);
            }
          }
  
          .slideOutUp {
            animation-name: slideOutUp;
          }`;
            animationsCSSStyleTag.innerHTML = $animationCSS;
            document.head.appendChild(animationsCSSStyleTag);
            modalCSSStyleTag.id = 'modalCSSID';
            modalCSSStyleTag.innerHTML = valuesObj.$modalCSS;
            document.head.appendChild(modalCSSStyleTag);
  
            let openModal = function() {
              document.body.style.overflow = "hidden";
              if(document.querySelector('.modal') !== null && document.querySelector('.modal').parentNode === document.body) {
                document.querySelector('.modal').parentNode.removeChild(document.querySelector('.modal'));
              }
  
              //HTML inside the modal and Input CSS animation tag
  
              document.body.innerHTML += 
                `<div class="modal" id="myModal">
                  <div class="modal-content-area animated bounce">
                  <i class="close-button" aria-hidden="true">&#10006;</i>
                    <h1 class="main-heading">Hello world</h1>
<h2>Welcome to modal.js editor.</h2>
<h3 class="third-heading">Edit me to put whatever you want.</h3>
                  </div>
                </div>`;
  
                //Output CSS animation name 
  
              classesToHide = ['modal-content-area', 'animated', 'bounce'];
              
              //Input CSS animation tag
  
              classesToRetainOriginal = ['modal-content-area', 'animated', 'bounce'];
              modal = document.getElementById('myModal');
              modalContent = document.querySelector('.modal-content-area');
  
              document.getElementsByClassName('close-button')[0].addEventListener('click', () => {
                animateToHide();
              });
              modal.style.display = "block";
            }
  
            window.addEventListener('click', (event) => {
              if (event.target === modal) {
                animateToHide();
              }
            });
  
            function animateToHide() {
              modalContent.className = '';
              modalContent.classList.add(...classesToHide);
              window.setTimeout(function () {
                  modal.style.display = "none";
                  retainToOriginal();
              }, 700);
            }
  
            function retainToOriginal() {
              modalContent.className = '';
              modalContent.classList.add(...classesToRetainOriginal);
              document.body.style.overflow = "auto";
            }