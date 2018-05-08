"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
require("rxjs/add/operator/map");
var BrukerSprsml_1 = require("./BrukerSprsml");
var Kundeservice = (function () {
    function Kundeservice(_http, fb) {
        this._http = _http;
        this.fb = fb;
        this.synkende = false;
        this.kolonne = '';
        this.skjema = fb.group({
            id: [""],
            sprsml: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("^[\\w\\W]{2,250}$")])],
            email: [null, forms_1.Validators.email]
        });
    }
    Kundeservice.prototype.ngOnInit = function () {
        this.searchString = "";
        this.laster = true;
        this.hentAlleBrukerSprsml();
        this.hentAlleFAQ();
        this.visSkjema = false;
        this.visBrukerSprsmlListe = false;
        this.visFAQListe = true;
    };
    Kundeservice.prototype.sort = function (property) {
        this.synkende = !this.synkende;
        this.kolonne = property;
        this.retning = this.synkende ? 1 : -1;
    };
    ;
    Kundeservice.prototype.hentAlleBrukerSprsml = function () {
        var _this = this;
        this._http.get("api/brukersprsml/")
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            _this.alleBrukerSprsml = [];
            if (JsonData) {
                for (var _i = 0, JsonData_1 = JsonData; _i < JsonData_1.length; _i++) {
                    var sprsmlObjekt = JsonData_1[_i];
                    _this.alleBrukerSprsml.push(sprsmlObjekt);
                    _this.laster = false;
                }
            }
            ;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get-api/brukersprsml"); });
    };
    ;
    Kundeservice.prototype.hentAlleFAQ = function () {
        var _this = this;
        this._http.get("api/faq/")
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            _this.alleFAQ = [];
            if (JsonData) {
                for (var _i = 0, JsonData_2 = JsonData; _i < JsonData_2.length; _i++) {
                    var faqObjekt = JsonData_2[_i];
                    _this.alleFAQ.push(faqObjekt);
                    _this.laster = false;
                }
                _this.hentAlleKategorier();
            }
            ;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get-api/faq"); });
    };
    ;
    Kundeservice.prototype.hentAlleKategorier = function () {
        var curr = this.alleFAQ.map(function (data) { return data.kategori; });
        this.alleKategorier = curr.filter(function (x, i, a) { return x && a.indexOf(x) === i; });
    };
    Kundeservice.prototype.vedSubmit = function () {
        if (this.skjemaStatus == "Registrere") {
            this.lagreBrukerSprsml();
        }
        else if (this.skjemaStatus == "Endre") {
            this.endreEtBrukerSprsml();
        }
        else {
            alert("Feil i applikasjonen!");
        }
    };
    Kundeservice.prototype.registrerSprsml = function () {
        this.skjema.setValue({
            id: "",
            sprsml: "",
            email: ""
        });
        this.skjema.markAsPristine();
        this.visBrukerSprsmlListe = false;
        this.visFAQListe = false;
        this.skjemaStatus = "Registrere";
        this.visSkjema = true;
    };
    Kundeservice.prototype.visBrukerSprsml = function () {
        this.visBrukerSprsmlListe = true;
        this.visSkjema = false;
        this.visFAQListe = false;
    };
    Kundeservice.prototype.visFAQ = function () {
        this.visBrukerSprsmlListe = false;
        this.visSkjema = false;
        this.visFAQListe = true;
    };
    Kundeservice.prototype.lagreBrukerSprsml = function () {
        var _this = this;
        var lagretSprsml = new BrukerSprsml_1.BrukerSprsml();
        lagretSprsml.sprsml = this.skjema.value.sprsml;
        lagretSprsml.email = this.skjema.value.email;
        var body = JSON.stringify(lagretSprsml);
        var headers = new http_1.Headers({ "Content-Type": "application/json" });
        this._http.post("api/brukersprsml", body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.hentAlleBrukerSprsml();
            _this.visSkjema = false;
            _this.visBrukerSprsmlListe = true;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig post-api/brukersprsml"); });
    };
    ;
    Kundeservice.prototype.sletteBrukerSprsml = function (id) {
        var _this = this;
        this._http.delete("api/brukersprsml/" + id)
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.hentAlleBrukerSprsml();
        }, function (error) { return alert(error); }, function () { return console.log("ferdig delete-api/brukersprsml"); });
    };
    ;
    Kundeservice.prototype.endreBrukerSprsml = function (id) {
        var _this = this;
        this._http.get("api/brukersprsml/" + id)
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            _this.skjema.patchValue({ id: JsonData.id });
            _this.skjema.patchValue({ sprsml: JsonData.sprsml });
            _this.skjema.patchValue({ email: JsonData.email });
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get-api/brukersprsml"); });
        this.skjemaStatus = "Endre";
        this.visSkjema = true;
        this.visBrukerSprsmlListe = false;
    };
    Kundeservice.prototype.endreEtBrukerSprsml = function () {
        var _this = this;
        var endretBrukerSprsml = new BrukerSprsml_1.BrukerSprsml();
        endretBrukerSprsml.sprsml = this.skjema.value.sprsml;
        endretBrukerSprsml.email = this.skjema.value.email;
        var body = JSON.stringify(endretBrukerSprsml);
        var headers = new http_1.Headers({ "Content-Type": "application/json" });
        this._http.put("api/brukersprsml/" + this.skjema.value.id, body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.hentAlleBrukerSprsml();
            _this.visSkjema = false;
            _this.visBrukerSprsmlListe = true;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig post-api/brukersprsml"); });
    };
    return Kundeservice;
}());
Kundeservice = __decorate([
    core_1.Component({
        selector: "min-app",
        templateUrl: "./app/kundeservice.html"
    }),
    __metadata("design:paramtypes", [http_1.Http, forms_1.FormBuilder])
], Kundeservice);
exports.Kundeservice = Kundeservice;
//# sourceMappingURL=kundeservice.component.js.map