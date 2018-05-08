import { Component, OnInit, Pipe, PipeTransform, Output, Input, EventEmitter, OnDestroy, HostListener } from "@angular/core";
import { Http, Response, Headers } from '@angular/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import "rxjs/add/operator/map";
import { BrukerSprsml } from "./BrukerSprsml";
import { FAQ } from "./FAQ";


@Component({
    selector: "min-app",
    templateUrl: "./app/kundeservice.html"
})


export class Kundeservice {
    public searchString: string;
    visSkjema: boolean;
    visFAQListe: boolean;
    skjemaStatus: string;
    visBrukerSprsmlListe: boolean;

    synkende: boolean = false;
    kolonne: string = '';
    retning: number;
 
    alleBrukerSprsml: BrukerSprsml[];
    alleFAQ: FAQ[];
    alleKategorier: String[];
    skjema: FormGroup;
    laster: boolean;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.skjema = fb.group({
            id: [""],
            sprsml: [null, Validators.compose([Validators.required, Validators.pattern("^[\\w\\W]{2,250}$")])],
            email: [null, Validators.email]
        });
    }



    ngOnInit() {
        this.searchString = "";
        this.laster = true;
        this.hentAlleBrukerSprsml();
        this.hentAlleFAQ();
        this.visSkjema = false;
        this.visBrukerSprsmlListe = false;
        this.visFAQListe = true;
    }

    sort(property: string) {
        this.synkende = !this.synkende;    
        this.kolonne = property;
        this.retning = this.synkende ? 1 : -1;
    };

    hentAlleBrukerSprsml() {
        this._http.get("api/brukersprsml/")
            .map(returData => {
                let JsonData = returData.json();
                return JsonData;
            })
            .subscribe(
            JsonData => {
                this.alleBrukerSprsml = [];
                if (JsonData) {
                    for (let sprsmlObjekt of JsonData) {
                        this.alleBrukerSprsml.push(sprsmlObjekt);
                        this.laster = false;
                    }
                };
            },
            error => alert(error),
            () => console.log("ferdig get-api/brukersprsml")
            );
    };

    hentAlleFAQ() {
        this._http.get("api/faq/")
            .map(returData => {
                let JsonData = returData.json();
                return JsonData;
            })
            .subscribe(
            JsonData => {
                this.alleFAQ = [];
                if (JsonData) {
                    for (let faqObjekt of JsonData) {
                        this.alleFAQ.push(faqObjekt);
                        this.laster = false;
                    }
                    this.hentAlleKategorier();
                };
            },
            error => alert(error),
            () => console.log("ferdig get-api/faq"),
        );
        
    };

    hentAlleKategorier() {
        const curr = this.alleFAQ.map(data => data.kategori);
        this.alleKategorier = curr.filter((x, i, a) => x && a.indexOf(x) === i);
    } 

    vedSubmit() {
        if (this.skjemaStatus == "Registrere") {
            this.lagreBrukerSprsml();
        }
        else if (this.skjemaStatus == "Endre") {
            this.endreEtBrukerSprsml();
        }
        else {
            alert("Feil i applikasjonen!");
        }
    }

    registrerSprsml() {
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
    }

    visBrukerSprsml() {
        this.visBrukerSprsmlListe = true;
        this.visSkjema = false;
        this.visFAQListe = false;
    }

    visFAQ() {
        this.visBrukerSprsmlListe = false;
        this.visSkjema = false;
        this.visFAQListe = true;
    }

    lagreBrukerSprsml() {
        var lagretSprsml = new BrukerSprsml();

        lagretSprsml.sprsml = this.skjema.value.sprsml;
        lagretSprsml.email = this.skjema.value.email;

        var body: string = JSON.stringify(lagretSprsml);
        var headers = new Headers({ "Content-Type": "application/json" });

        this._http.post("api/brukersprsml", body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.hentAlleBrukerSprsml();
                this.visSkjema = false;
                this.visBrukerSprsmlListe = true;
            },
            error => alert(error),
            () => console.log("ferdig post-api/brukersprsml")
            );
    };

    sletteBrukerSprsml(id: number) {
        this._http.delete("api/brukersprsml/" + id)
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.hentAlleBrukerSprsml();
            },
            error => alert(error),
            () => console.log("ferdig delete-api/brukersprsml")
            );
    };

    endreBrukerSprsml(id: number) {
        this._http.get("api/brukersprsml/" + id)
            .map(returData => {
                let JsonData = returData.json();
                return JsonData;
            })
            .subscribe(
            JsonData => { // legg de hentede data inn i feltene til endreSkjema. Kan bruke setValue også her da hele skjemaet skal oppdateres. 
                this.skjema.patchValue({ id: JsonData.id });
                this.skjema.patchValue({ sprsml: JsonData.sprsml });
                this.skjema.patchValue({ email: JsonData.email });
            },
            error => alert(error),
            () => console.log("ferdig get-api/brukersprsml")
            );
        this.skjemaStatus = "Endre";
        this.visSkjema = true;
        this.visBrukerSprsmlListe = false;
    }

    endreEtBrukerSprsml() {
        var endretBrukerSprsml = new BrukerSprsml();

        endretBrukerSprsml.sprsml = this.skjema.value.sprsml;
        endretBrukerSprsml.email = this.skjema.value.email;

        var body: string = JSON.stringify(endretBrukerSprsml);
        var headers = new Headers({ "Content-Type": "application/json" });

        this._http.put("api/brukersprsml/" + this.skjema.value.id, body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.hentAlleBrukerSprsml();
                this.visSkjema = false;
                this.visBrukerSprsmlListe = true;
            },
            error => alert(error),
            () => console.log("ferdig post-api/brukersprsml")
            );
    }
}