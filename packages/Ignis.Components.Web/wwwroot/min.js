(()=>{"use strict";var e={647:function(e,t,n){var o=this&&this.__awaiter||function(e,t,n,o){return new(n||(n=Promise))((function(r,s){function i(e){try{l(o.next(e))}catch(e){s(e)}}function c(e){try{l(o.throw(e))}catch(e){s(e)}}function l(e){var t;e.done?r(e.value):(t=e.value,t instanceof n?t:new n((function(e){e(t)}))).then(i,c)}l((o=o.apply(e,t||[])).next())}))};Object.defineProperty(t,"__esModule",{value:!0}),t.ScrollDetector=void 0;const r=n(734);class s extends r.ComponentBase{constructor(e){super(e,"Ignis.Components.Web.ScrollDetector"),this._onScroll=()=>{this.onScroll()},window.addEventListener("scroll",this._onScroll),this._onScroll()}onScroll(){return o(this,void 0,void 0,(function*(){yield this.$ref.invokeMethodAsync("OnScrollAsync",window.scrollX,window.scrollY)}))}dispose(){super.dispose(),window.removeEventListener("scroll",this._onScroll)}}t.ScrollDetector=s},530:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.ComponentBase=void 0;class n{get $ref(){return n._instances[this._id]._ref}constructor(e,t){this._ref=e,this._id=t;let o=n._instances[t];o&&o.dispose(),n._instances[t]=this}dispose(){delete n._instances[this._id]}}t.ComponentBase=n,n._instances={}},734:(e,t,n)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.registerComponent=t.ComponentBase=void 0;var o=n(530);Object.defineProperty(t,"ComponentBase",{enumerable:!0,get:function(){return o.ComponentBase}});var r=n(499);Object.defineProperty(t,"registerComponent",{enumerable:!0,get:function(){return r.registerComponent}})},499:(e,t)=>{Object.defineProperty(t,"__esModule",{value:!0}),t.registerComponent=void 0,t.registerComponent=function(e,t){let n=window;const o=e.split(".");for(;o.length>1;){const e=o.shift();n[e]||(n[e]={}),n=n[e]}n[o.shift()]=(e,...n)=>new t(e,...n)}}},t={};function n(o){var r=t[o];if(void 0!==r)return r.exports;var s=t[o]={exports:{}};return e[o].call(s.exports,s,s.exports,n),s.exports}(()=>{const e=n(734),t=n(647);(0,e.registerComponent)("Ignis.Components.Web.ScrollDetector",t.ScrollDetector)})()})();